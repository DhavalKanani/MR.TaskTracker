using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Exceptions;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.UpdateTaskAssignment
{
    public class UpdateTaskAssignmentCommandHandler : IRequestHandler<UpdateTaskAssignmentCommand, TaskAssignmentQueryDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;

        public UpdateTaskAssignmentCommandHandler(IMapper mapper, IUserService userService, ITaskAssignmentRepository taskAssignmentRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _taskAssignmentRepository = taskAssignmentRepository;
        }

        public async Task<TaskAssignmentQueryDto> Handle(UpdateTaskAssignmentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserFromContext();
            var validator = new UpdateTaskAssignmentCommandValidator(_taskAssignmentRepository, user);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Task Attachment", validationResult);

            var taskAssignment = await _taskAssignmentRepository.GetByIdAsync(request.TaskAssignment.Id);

            if (request.Field == UpdatableField.CurrentStatus.ToString())
            {
                taskAssignment.CurrentStatus = request.TaskAssignment.CurrentStatus;
            }
            else if(request.Field == UpdatableField.StoryPoint.ToString())
            {
                taskAssignment.StoryPoint = request.TaskAssignment.StoryPoint;
            }

            await _taskAssignmentRepository.UpdateAsync(taskAssignment);
            return _mapper.Map<TaskAssignmentQueryDto>(taskAssignment);
        }
    }
}

