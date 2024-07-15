using FluentValidation;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.CreateTaskAssignment
{
    public class CreateTaskAssignmentCommandValidator : AbstractValidator<CreateTaskAssignmentCommand>
    {
        public CreateTaskAssignmentCommandValidator()
        {
            RuleFor(p => p.TaskAssignment)
                .NotNull()
                .WithMessage("TaskAssignment required");
            RuleFor(p => p.TaskAssignment.Title).NotEmpty();
            RuleFor(p => p.TaskAssignment.Description).NotNull();
            RuleFor(p => p.TaskAssignment.CurrentStatus).NotEmpty();
            RuleFor(p => p.TaskAssignment.ReporterId).NotEmpty();
        }
    }
}

