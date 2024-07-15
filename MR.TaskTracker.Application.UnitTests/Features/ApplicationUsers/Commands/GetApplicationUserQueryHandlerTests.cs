using AutoMapper;
using Moq;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Logging;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Features.Employees.Queries.GetApplicationUsers;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments;
using MR.TaskTracker.Application.MappingProfiles;
using MR.TaskTracker.Application.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace MR.TaskTracker.Application.UnitTests.Features.ApplicationUsers.Commands
{
    public class GetApplicationUserQueryHandlerTests
	{

        private readonly IMapper _mapper;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private IUserService _userService;
        private readonly IAppLogger<GetAllTaskAssignmentsQueryHandler> _logger;

        public GetApplicationUserQueryHandlerTests()
		{
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ApplicationUserProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _applicationUserRepository = MockApplicationUserRepository.GetMockApplicationUserRepository().Object;
            _logger = new Mock<IAppLogger<GetAllTaskAssignmentsQueryHandler>>().Object;
        }

        [Fact]
        public async Task Handle_GetApplicationUserQuery_ADMIN()
        {
            _userService = MockUserService.GetMockUserService("ADMIN").Object;

            var handler = new GetApplicationUserQueryHandler(_mapper, _applicationUserRepository, _userService,_logger);

            var actualApplicationUsers = await handler.Handle(new GetApplicationUserQuery(), CancellationToken.None);
            actualApplicationUsers.ShouldNotBe(null);
            actualApplicationUsers.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GetApplicationUserQuery_EMPLOYEE()
        {
            _userService = MockUserService.GetMockUserService("EMPLOYEE").Object;

            var handler = new GetApplicationUserQueryHandler(_mapper, _applicationUserRepository, _userService, _logger);

            var actualApplicationUsers = await handler.Handle(new GetApplicationUserQuery(), CancellationToken.None);
            actualApplicationUsers.ShouldNotBe(null);
            actualApplicationUsers.Count.ShouldBe(2);
        }
    }
}

