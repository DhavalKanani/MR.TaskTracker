using MediatR;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment
{
    public class AddAttachmentCommand : IRequest<TaskAttachmentQueryDto>
    {
        public TaskAttachmentCommandDto TaskAttachment;
    }
}