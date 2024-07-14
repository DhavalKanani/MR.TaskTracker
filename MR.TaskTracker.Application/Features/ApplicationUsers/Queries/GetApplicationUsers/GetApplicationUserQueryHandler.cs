using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Logging;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments;

namespace MR.TaskTracker.Application.Features.Employees.Queries.GetApplicationUsers
{
    public class GetApplicationUserQueryHandler : IRequestHandler<GetApplicationUserQuery, List<ApplicationUserQueryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserService _userService;
        private readonly IAppLogger<GetAllTaskAssignmentsQueryHandler> _logger;

        public GetApplicationUserQueryHandler(IMapper mapper,
            IApplicationUserRepository applicationUserRepository,
            IUserService userService,
            IAppLogger<GetAllTaskAssignmentsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._userService = userService;
            this._applicationUserRepository = applicationUserRepository;
            this._logger = logger;
        }

        public async Task<List<ApplicationUserQueryDto>> Handle(GetApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var contextUser = await _userService.GetUserFromContext();
            var taskAssignments = await _applicationUserRepository.GetUsers(contextUser.Id,contextUser.Role);
            return _mapper.Map<List<ApplicationUserQueryDto>>(taskAssignments);
        }
    }
}

