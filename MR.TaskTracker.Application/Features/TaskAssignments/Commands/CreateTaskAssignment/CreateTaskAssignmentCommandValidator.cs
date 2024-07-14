using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.CreateTaskAssignment
{
    public class CreateTaskAssignmentCommandValidator : AbstractValidator<CreateTaskAssignmentCommand>
    {
        public CreateTaskAssignmentCommandValidator()
        {
            RuleFor(p => p.TaskAssignment).NotNull();
            RuleFor(p => p.TaskAssignment.Title).NotEmpty();
            RuleFor(p => p.TaskAssignment.Description).NotNull();
            RuleFor(p => p.TaskAssignment.ReporterId).NotEmpty();
        }
    }
}

