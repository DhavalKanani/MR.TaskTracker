using MR.TaskTracker.Domain.Common;

namespace MR.TaskTracker.Domain;

public class TaskAction : BaseEntity
{
    public int TaskAssignmentId { get; set; }
    public TaskAssignment? TaskAssignment { get; set; }

    public string FromStatus { get; set; } = string.Empty;

    public string ToStatus { get; set; } = string.Empty;
}