using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment
{
    public class AddAttachmentCommandValidator : AbstractValidator<AddAttachmentCommand>
    {
        public AddAttachmentCommandValidator()
        {
            RuleFor(p => p.TaskAttachment).NotNull();
            RuleFor(p => p.TaskAttachment.ById).NotNull();
            RuleFor(p => p.TaskAttachment.TaskAssignmentId).NotNull();
            RuleFor(p => p.TaskAttachment.Attachment).NotNull();
        }
    }
}