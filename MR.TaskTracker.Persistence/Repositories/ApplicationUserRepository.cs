using Microsoft.EntityFrameworkCore;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Persistence.DatabaseContext;

namespace MR.TaskTracker.Persistence.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(MrDatabaseContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IReadOnlyList<ApplicationUser>> GetUsers(int userId, string role)
        {
            if(role == ApplicationUserRole.ADMIN.ToString())
            {
                return await GetAsync();
            }
            else
            {
                return await _context.ApplicationUsers.Where(e => e.Id == userId || e.ReportsToId == userId).ToListAsync();
            }
             
        }
    }
}
