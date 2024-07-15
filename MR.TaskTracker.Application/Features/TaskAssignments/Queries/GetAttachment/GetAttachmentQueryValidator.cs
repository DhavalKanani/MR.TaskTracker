using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAttachment
{
    public class GetAttachmentQueryValidator : AbstractValidator<GetAttachmentQuery>{

        public GetAttachmentQueryValidator()
        {
            RuleFor(p => p.TaskAttachmentId)
                .NotEmpty()
                .GreaterThan(1)
                .WithMessage("TaskAttachmentId required");
        }

    }

}

