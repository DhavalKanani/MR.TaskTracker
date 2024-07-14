namespace MR.TaskTracker.Application.Dtos.Queries
{
    public class TaskAssignmentQueryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public decimal StoryPoint { get; set; }
        public DateTimeOffset DueDate { get; set; }

        public int AssigneeId { get; set; }
        public ApplicationUserQueryDto? Assignee { get; set; }

        public int ReporterId { get; set; }
        public ApplicationUserQueryDto? Reporter { get; set; }

        public ICollection<TaskActionQueryDto>? Actions { get; set; } = new List<TaskActionQueryDto>();
        public ICollection<TaskAttachmentQueryDto>? Attachments { get; set; } = new List<TaskAttachmentQueryDto>();
        public ICollection<TaskCommentQueryDto>? Comments { get; set; } = new List<TaskCommentQueryDto>();
    }
}

