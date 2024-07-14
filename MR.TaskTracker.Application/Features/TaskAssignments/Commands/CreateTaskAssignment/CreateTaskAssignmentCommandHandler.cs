using AutoMapper;
using MediatR;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.CreateTaskAssignment
{
    public class CreateTaskAssignmentCommandHandler : IRequestHandler<CreateTaskAssignmentCommand, TaskAssignmentQueryDto>
    {
        public readonly IMapper _mapper;
        public readonly ITaskAssignmentRepository _taskAssignmentRepository;
        public CreateTaskAssignmentCommandHandler(IMapper mapper, ITaskAssignmentRepository taskAssignmentRepository)
        {
            _mapper = mapper;
            _taskAssignmentRepository = taskAssignmentRepository;
        }

        public async Task<TaskAssignmentQueryDto> Handle(CreateTaskAssignmentCommand request, CancellationToken cancellationToken)
        {
            var taskAssignment =  _mapper.Map<TaskAssignment>(request.TaskAssignment);
            var task = await _taskAssignmentRepository.CreateAsync(taskAssignment);
            return _mapper.Map<TaskAssignmentQueryDto>(task);

        }
    }
}

