using Moq;
using MR.TaskTracker.Application.Contracts.Identity;

namespace MR.TaskTracker.Application.UnitTests.Mocks
{
    public class MockUserService
    {
        public static Mock<IUserService> GetMockUserService(string role)
        {
            var mockService = new Mock<IUserService>();

            mockService.Setup(r => r.GetUserFromContext()).ReturnsAsync(new Models.Identity.ApplicationUserModel
            {
                Id=2,
                UserName = "test@mr.tasktracker.com",
                Email = "test@mr.tasktracker.com",
                Role = role,
            });
            
            return mockService;
        }
    }
}

