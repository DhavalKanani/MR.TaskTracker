namespace MR.TaskTracker.Application.Dtos.Queries
{
    public class TaskAttachmentQueryDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;

        public int ById { get; set; }
        public ApplicationUserQueryDto? By { get; set; }
    }

}

