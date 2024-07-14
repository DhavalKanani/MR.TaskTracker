using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Logging;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetTask
{
	public class GetTaskAssignmentQuery : IRequest<TaskAssignmentQueryDto>
	{
        public int Id { get; set; }
    }
    public class GetTaskQueryHandler : IRequestHandler<GetTaskAssignmentQuery, TaskAssignmentQueryDto>
    {
        private readonly IMapper _mapper;
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;
        private readonly IAppLogger<GetAllTaskAssignmentsQueryHandler> _logger;

        public GetTaskQueryHandler(IMapper mapper,
            ITaskAssignmentRepository taskAssignmentRepository,
            IAppLogger<GetAllTaskAssignmentsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._taskAssignmentRepository = taskAssignmentRepository;
            this._logger = logger;
        }

        public async Task<TaskAssignmentQueryDto> Handle(GetTaskAssignmentQuery request, CancellationToken cancellationToken)
        {
            var taskAssignment = await _taskAssignmentRepository.GetTaskAssignmentWithDetails(request.Id);
            return _mapper.Map<TaskAssignmentQueryDto>(taskAssignment);
            
        }
    }
}

