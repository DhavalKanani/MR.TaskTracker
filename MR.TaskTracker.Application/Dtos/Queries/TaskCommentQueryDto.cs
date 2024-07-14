namespace MR.TaskTracker.Application.Dtos.Queries
{
    public class TaskCommentQueryDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int ById { get; set; }
        public ApplicationUserQueryDto? By { get; set; }
    }

}

