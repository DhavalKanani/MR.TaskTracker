using AutoMapper;
using MediatR;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Exceptions;
using MR.TaskTracker.Application.Extensions;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment
{
    public class AddAttachmentCommandHandler : IRequestHandler<AddAttachmentCommand, TaskAttachmentQueryDto>
    {
        public readonly IMapper _mapper;
        public readonly ITaskAttachmentRepository _taskAttachmentRepository;

        public AddAttachmentCommandHandler(IMapper mapper, ITaskAttachmentRepository taskAttachmentRepository)
        {
            _mapper = mapper;
            _taskAttachmentRepository = taskAttachmentRepository;
        }

        public async Task<TaskAttachmentQueryDto> Handle(AddAttachmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddAttachmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Task Attachment", validationResult);

            var taskAttachment = _mapper.Map<TaskAttachment>(request.taskAttachment);

            var file = await request.taskAttachment.Attachment.ToFileModel();
            taskAttachment.Content = file.Content;
            taskAttachment.FileName = file.FileName;
            taskAttachment.Length = file.Length;

            await _taskAttachmentRepository.CreateAsync(taskAttachment);

            return _mapper.Map<TaskAttachmentQueryDto>(request.taskAttachment);
        }
    }
}