
namespace MR.TaskTracker.Application.Dtos.Command
{
    public class TaskAssignmentCommandDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public decimal StoryPoint { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public int AssigneeId { get; set; }
        public int ReporterId { get; set; }
        public IList<TaskAttachmentCommandDto>? Attachments { get; set; } = new List<TaskAttachmentCommandDto>();
    }
}

