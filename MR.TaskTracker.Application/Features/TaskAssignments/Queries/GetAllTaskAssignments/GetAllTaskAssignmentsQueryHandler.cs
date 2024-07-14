using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Logging;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments
{
    public class GetAllTaskAssignmentsQueryHandler :IRequestHandler<GetAllTaskAssignmentsQuery, List<TaskAssignmentQueryDto>>
	{
        private readonly IMapper _mapper;
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;
        private readonly IAppLogger<GetAllTaskAssignmentsQueryHandler> _logger;

        public GetAllTaskAssignmentsQueryHandler(IMapper mapper,
            ITaskAssignmentRepository taskAssignmentRepository,
            IAppLogger<GetAllTaskAssignmentsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._taskAssignmentRepository = taskAssignmentRepository;
            this._logger = logger;
        }

        public async Task<List<TaskAssignmentQueryDto>> Handle(GetAllTaskAssignmentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllTaskAssignmentsQuery");
            var taskAssignments = await _taskAssignmentRepository.GetTaskAssignmentsByFilter(request.AssigneeId,request.ReporterId,request.DueDate);
            return _mapper.Map<List<TaskAssignmentQueryDto>>(taskAssignments);
        }
    }
}

