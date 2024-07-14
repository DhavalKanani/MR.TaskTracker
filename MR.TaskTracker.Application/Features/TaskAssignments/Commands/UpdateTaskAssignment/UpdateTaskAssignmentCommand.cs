using System;
using MediatR;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.UpdateTaskAssignment
{
    public class UpdateTaskAssignmentCommand : IRequest<TaskAssignmentQueryDto>
	{
        public TaskAssignmentCommandDto? TaskAssignment { get; set; }
        public string Field { get; set; } = String.Empty;
    }
}

