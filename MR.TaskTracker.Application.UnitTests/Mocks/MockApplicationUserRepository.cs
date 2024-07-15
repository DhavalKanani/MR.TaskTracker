using Moq;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.UnitTests.Mocks
{
    public class MockApplicationUserRepository
	{
        public static Mock<IApplicationUserRepository> GetMockApplicationUserRepository()
        {
            IReadOnlyList<ApplicationUser> applicationUsers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id= 1,
                    UserName ="1@mr.tasktracker.com",
                    Email ="1@mr.tasktracker.com",
                    Role = ApplicationUserRole.ADMIN.ToString(),
                    ReportsToId=1,
                },
                new ApplicationUser
                {
                    Id=2,
                    UserName ="2@mr.tasktracker.com",
                    Email ="2@mr.tasktracker.com",
                    Role = ApplicationUserRole.EMPLOYEE.ToString(),
                    ReportsToId=1,
                },
                new ApplicationUser
                {
                    Id= 3,
                    UserName ="3@mr.tasktracker.com",
                    Email ="3@mr.tasktracker.com",
                    Role = ApplicationUserRole.EMPLOYEE.ToString(),
                    ReportsToId=2,
                }
            }.AsReadOnly();

            var mockRepo = new Mock<IApplicationUserRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(applicationUsers);
            mockRepo.Setup(r => r.GetUsers(It.IsAny<int>(), It.IsAny<string>()))
                .Returns<int, string>((userId, role) =>
                {
                    if(role == ApplicationUserRole.ADMIN.ToString())
                    {
                        return Task.FromResult(applicationUsers);
                    }
                    var accessibleUsers = applicationUsers.Where(e => e.Id == userId || e.ReportsToId == userId).ToList();
                    return Task.FromResult((IReadOnlyList<ApplicationUser>)accessibleUsers);
                });

            return mockRepo;
        }
    }
}

