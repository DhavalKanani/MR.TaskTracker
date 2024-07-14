using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Contracts.Persistence
{
    public interface ITaskAssignmentRepository : IGenericRepository<TaskAssignment>
    {
		public Task<TaskAssignment> GetTaskAssignmentWithDetails(int taskId);
        public Task<bool> CanUserAccess(int userId, int taskId);
        public Task<List<TaskAssignment>> GetTaskAssignmentsByFilter(int? assigneeId, int? reporterId, DateTimeOffset? dueDate);
    }
}
