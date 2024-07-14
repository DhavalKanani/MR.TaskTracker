namespace MR.TaskTracker.Application.Models.Identity
{
    public class ApplicationUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int ReportsToId { get; set; }
        public string Role { get; set; }
    }
}
