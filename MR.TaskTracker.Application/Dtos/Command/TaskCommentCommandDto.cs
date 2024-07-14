namespace MR.TaskTracker.Application.Dtos.Command
{
    public class TaskCommentCommandDto
    {
        public string Comment { get; set; } = string.Empty;
        public int? TaskAssignmentId { get; set; }
        public int? ById { get; set; }
    }
}

