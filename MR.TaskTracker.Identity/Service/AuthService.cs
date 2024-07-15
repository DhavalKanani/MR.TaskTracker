using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Exceptions;
using MR.TaskTracker.Application.Models.Identity;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Identity.Service
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserService _userService;

        public AuthService(IApplicationUserRepository applicationUserRepository,
            IOptions<JwtSettings> jwtSettings,
            IUserService userService)
        {
            _applicationUserRepository = applicationUserRepository;
            _jwtSettings = jwtSettings.Value;
            _userService = userService;
        }

        public async Task<AuthResponse> ChangePassword(AuthRequest request)
        {
            var user = await _applicationUserRepository.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password);
            await _applicationUserRepository.UpdateAsync(user);

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _applicationUserRepository.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            var result = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.Password);

            if (!result)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
                Role=user.Role
            };

            return response;
        }


        public async Task Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password),
                ReportsToId = request.ReportsToId,
                Role = request.Role
            };

            await _applicationUserRepository.CreateAsync(user);
        }

        public async Task<AuthResponse> VerifyToken(string token)
        {

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var response = new AuthResponse
            {
                Id = int.Parse(jwtSecurityToken.Claims.First(x => x.Type == ClaimTypes.Actor).Value),
                Token = handler.WriteToken(jwtSecurityToken),
                Email = jwtSecurityToken.Claims.First(x => x.Type == ClaimTypes.Email).Value,
                UserName = jwtSecurityToken.Claims.First(x => x.Type == ClaimTypes.Email).Value,
                Role = jwtSecurityToken.Claims.First(x => x.Type == ClaimTypes.Role).Value
            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Actor,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}

