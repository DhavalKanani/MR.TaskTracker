using Microsoft.AspNetCore.Http;

namespace MR.TaskTracker.Application.Dtos.Command
{
    public class TaskAttachmentCommandDto
    {
        public int? TaskAssignmentId { get; set; }
        public int? ById { get; set; }
        public IFormFile? Attachment { get; set; }
    }
}

