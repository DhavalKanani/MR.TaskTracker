using FluentValidation;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Models.Identity;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.UpdateTaskAssignment
{
    public class UpdateTaskAssignmentCommandValidator : AbstractValidator<UpdateTaskAssignmentCommand>
    {

        private readonly ITaskAssignmentRepository _taskAssignmentRepository;
        private readonly ApplicationUserModel _user;

        public UpdateTaskAssignmentCommandValidator(ITaskAssignmentRepository taskAssignmentRepository, ApplicationUserModel user)
        {
            _taskAssignmentRepository = taskAssignmentRepository;
            _user = user;
            RuleFor(e => e)
                .MustAsync(CanUserUpdate)
                .WithMessage("You dont have access to update Task");

            RuleFor(e => e.Field)
                .Must(p => Enum.GetNames(typeof(UpdatableField)).ToList().Contains(p))
                .WithMessage(p => string.Format("You cant update {0}", p.Field));
        }

        private async Task<bool> CanUserUpdate(UpdateTaskAssignmentCommand request, CancellationToken token)
        {
            return await _taskAssignmentRepository.CanUserAccess(_user.Id, request.TaskAssignment.Id);
        }

    }
}

