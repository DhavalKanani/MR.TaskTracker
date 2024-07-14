using MR.TaskTracker.Domain.Common;

namespace MR.TaskTracker.Domain;

public class TaskAssignment : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string CurrentStatus { get; set; } = string.Empty;

    public decimal StoryPoint { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public int AssigneeId { get; set; }
    public ApplicationUser? Assignee { get; set; }

    public int ReporterId { get; set; }
    public ApplicationUser? Reporter { get; set; }

    public ICollection<TaskAction>? Actions { get; set; } = new List<TaskAction>();
    public ICollection<TaskAttachment>? Attachments { get; set; } = new List<TaskAttachment>();
    public ICollection<TaskComment>? Comments { get; set; } = new List<TaskComment>();
}
