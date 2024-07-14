using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MR.TaskTracker.Application.Contracts.Identity;

namespace MR.TaskTracker.Persistence.Repositories
{
    public class TaskAssignmentRepository : GenericRepository<TaskAssignment>, ITaskAssignmentRepository
    {
        private readonly IUserService _userService;
        public TaskAssignmentRepository(MrDatabaseContext context, IUserService userService) : base(context)
        {
            _userService = userService;
        }

        public async Task<bool> CanUserAccess(int userId, int taskId)
        {
            var task = await _context.TaskAssignments
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == taskId && (t.ReporterId == userId || t.AssigneeId == userId));

            if (task == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<TaskAssignment>> GetTaskAssignmentsByFilter(int? assigneeId, int? reporterId, DateTimeOffset? dueDate)
        {

            var userContext = await _userService.GetUserFromContext();

            if(userContext.Role != ApplicationUserRole.ADMIN.ToString())
            {
                return await GetTaskAssignmentsByUser(userContext.Id);
            }

            var taskAssignments = _context.TaskAssignments.AsQueryable();
            if (assigneeId != null)
            {
                taskAssignments = taskAssignments.Where(t => t.AssigneeId == assigneeId);
            }

            if (reporterId != null)
            {
                taskAssignments = taskAssignments.Where(t => t.ReporterId == reporterId);
            }

            if (dueDate != null)
            {
                taskAssignments = taskAssignments.Where(t => t.CurrentStatus != TaskAssignmentStatus.DONE.ToString() && t.DueDate <= dueDate.Value);
            }

            return await taskAssignments.ToListAsync();
        }

        public async Task<List<TaskAssignment>> GetTaskAssignmentsByUser(int userId)
        {
            var taskAssignments = _context.TaskAssignments.Where(t => t.AssigneeId == userId || t.ReporterId == userId);
            return await taskAssignments.ToListAsync();
        }


        public async Task<TaskAssignment> GetTaskAssignmentWithDetails(int taskId)
        {
            var task = await _context.TaskAssignments
                .Include(t => t.Comments)
                .Include(t => t.Attachments)
                .Include(t => t.Actions)
                .Include(t => t.Assignee)
                .Include(t => t.Reporter)
                .FirstOrDefaultAsync(t => t.Id ==taskId);
            return task;
        }
    }
}
