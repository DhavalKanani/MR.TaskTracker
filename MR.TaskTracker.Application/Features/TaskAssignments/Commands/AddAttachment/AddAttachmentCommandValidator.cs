using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment
{
    public class AddAttachmentCommandValidator : AbstractValidator<AddAttachmentCommand>
    {
        public AddAttachmentCommandValidator()
        {
            RuleFor(p => p.taskAttachment).NotNull();
            RuleFor(p => p.taskAttachment.ById).NotNull();
            RuleFor(p => p.taskAttachment.TaskAssignmentId).NotNull();
            RuleFor(p => p.taskAttachment.Attachment).NotNull();

        }
    }
}