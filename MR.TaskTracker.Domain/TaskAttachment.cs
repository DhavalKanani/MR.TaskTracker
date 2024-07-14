using MR.TaskTracker.Domain.Common;

namespace MR.TaskTracker.Domain;

public class TaskAttachment : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public long Length { get; set; }
    public byte[]? Content { get; set; }

    public int TaskAssignmentId { get; set; }
    public TaskAssignment? TaskAssignment { get; set; }

    public int ById { get; set; }
    public ApplicationUser? By { get; set; }

}
