using MR.TaskTracker.Domain.Common;

namespace MR.TaskTracker.Domain;

public class ApplicationUser : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public int ReportsToId { get; set; }
    public ApplicationUser? ReportsTo { get; set; }

    public ICollection<ApplicationUser> Reports { get; set; } = new List<ApplicationUser>();
    public ICollection<TaskAssignment> TasksAssigned { get; set; } = new List<TaskAssignment>();
    public ICollection<TaskAssignment> TasksReported { get; set; } = new List<TaskAssignment>();
}