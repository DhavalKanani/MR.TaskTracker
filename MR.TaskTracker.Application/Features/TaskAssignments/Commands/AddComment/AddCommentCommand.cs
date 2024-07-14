using System;
using MediatR;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment
{
    public class AddCommentCommand : IRequest<TaskCommentQueryDto>
	{
		public TaskCommentCommandDto taskComment;
	}
}

