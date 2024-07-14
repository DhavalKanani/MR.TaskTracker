using MR.TaskTracker.Application.Models.Identity;

namespace MR.TaskTracker.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<AuthResponse> VerifyToken(string token);
        Task<AuthResponse> ChangePassword(AuthRequest request);
        Task Register(RegistrationRequest request);
    }
}

