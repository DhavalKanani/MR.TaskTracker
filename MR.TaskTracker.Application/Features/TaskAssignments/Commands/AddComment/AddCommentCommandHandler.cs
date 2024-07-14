using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Exceptions;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, TaskCommentQueryDto>
    {
        public readonly IMapper _mapper;
        public readonly ITaskCommentRepository _taskCommentRepository;
        public AddCommentCommandHandler(IMapper mapper, ITaskCommentRepository taskCommentRepository)
        {
            _mapper = mapper;
            _taskCommentRepository = taskCommentRepository;
        }
        public async Task<TaskCommentQueryDto> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddCommentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Task Attachment", validationResult);

            var taskComment = _mapper.Map<TaskComment>(request.taskComment);
            await _taskCommentRepository.CreateAsync(taskComment);
            return _mapper.Map<TaskCommentQueryDto>(request.taskComment);
        }
    }
}

