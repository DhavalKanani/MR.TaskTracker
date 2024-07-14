using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Persistence.DatabaseContext;

namespace MR.TaskTracker.Persistence.Repositories
{
    public class TaskCommentRepository : GenericRepository<TaskComment>, ITaskCommentRepository
    {
        public TaskCommentRepository(MrDatabaseContext context) : base(context)
        {
        }
    }
}
