using System;
using MediatR;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.CreateTaskAssignment
{
    public class CreateTaskAssignmentCommand : IRequest<TaskAssignmentQueryDto>
	{
        public TaskAssignmentCommandDto TaskAssignment { get; set; }
    }
}

