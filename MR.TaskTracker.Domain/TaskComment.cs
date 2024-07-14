using MR.TaskTracker.Domain.Common;

namespace MR.TaskTracker.Domain;

public class TaskComment : BaseEntity
{
    public int TaskAssignmentId { get; set; }
    public TaskAssignment? TaskAssignment { get; set; }

    public string Comment { get; set; } = string.Empty;

    public int ById { get; set; }
    public ApplicationUser? By { get; set; }
}
