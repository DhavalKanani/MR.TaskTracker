using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Models.Identity;

namespace MR.TaskTracker.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthController(IAuthService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        /// <summary>
        /// Login API
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }
        
        /// <summary>
        /// API to verify token
        /// </summary>
        /// <param name="token"></param>
        [HttpGet("verifyToken")]
        [Authorize]
        public async Task<ActionResult<AuthResponse>> VerifyToken([FromQuery]string token)
        {
            return Ok(await _authenticationService.VerifyToken(token));
        }

        /// <summary>
        /// change password 
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("changePassword")]
        [Authorize]
        public async Task<ActionResult<AuthResponse>> ChangePassword(AuthRequest request)
        {
            return Ok(await _authenticationService.ChangePassword(request));
        }

        /// <summary>
        /// Create new User, Only Admin can create new user
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("register")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            await _authenticationService.Register(request);
            return Ok();
        }
    }
}