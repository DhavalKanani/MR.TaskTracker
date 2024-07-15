using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(p => p.TaskComment).NotNull();
            RuleFor(p => p.TaskComment.ById).NotNull();
            RuleFor(p => p.TaskComment.TaskAssignmentId).NotNull();
            RuleFor(p => p.TaskComment.Comment).NotEmpty();
        }
    }
}

