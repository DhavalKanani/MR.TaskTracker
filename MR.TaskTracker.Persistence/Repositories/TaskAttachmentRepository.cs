using Microsoft.EntityFrameworkCore;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Persistence.DatabaseContext;

namespace MR.TaskTracker.Persistence.Repositories
{
    public class TaskAttachmentRepository : GenericRepository<TaskAttachment>, ITaskAttachmentRepository
    {
        public TaskAttachmentRepository(MrDatabaseContext context) : base(context)
        {
        }
    }
}
