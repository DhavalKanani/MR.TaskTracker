using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(p => p.taskComment).NotNull();
            RuleFor(p => p.taskComment.ById).NotNull();
            RuleFor(p => p.taskComment.TaskAssignmentId).NotNull();
            RuleFor(p => p.taskComment.Comment).NotEmpty();
        }
    }
}

