using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Contracts.Persistence
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        public Task<IReadOnlyList<ApplicationUser>> GetUsers(int employeeId,string role);
    }
}
