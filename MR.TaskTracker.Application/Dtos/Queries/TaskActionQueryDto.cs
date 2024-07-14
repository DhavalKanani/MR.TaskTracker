namespace MR.TaskTracker.Application.Dtos.Queries
{
    public class TaskActionQueryDto
    {
        public int Id { get; set; }
        public string FromStatus { get; set; } = string.Empty;
        public string ToStatus { get; set; } = string.Empty;
    }

}

