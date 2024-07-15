using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddComment;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/TaskComment
        /// <summary>
        /// Add comment to task
        /// </summary>
        /// <param name="taskComment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ApplicationUserQueryDto>>> Post(TaskCommentCommandDto taskComment)
        {
            var response = await _mediator.Send(new AddCommentCommand { TaskComment = taskComment});
            return Ok(response);
        }
    }
}

