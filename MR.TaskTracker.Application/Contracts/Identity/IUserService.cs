using MR.TaskTracker.Application.Models.Identity;

namespace MR.TaskTracker.Application.Contracts.Identity
{
    public interface IUserService
	{
        Task<ApplicationUserModel> GetUserFromContext();
    }
}