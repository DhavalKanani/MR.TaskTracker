using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.AddAttachment;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAttachment;

namespace MR.TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskAttachmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskAttachmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/TaskAttachment
        /// <summary>
        /// Add attachment to task
        /// </summary>
        /// <param name="taskattachment"></param>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] TaskAttachmentCommandDto taskattachment)
        {
            var response = await _mediator.Send(new AddAttachmentCommand { taskAttachment = taskattachment});
            return Ok(response);
        }

        /// <summary>
        /// Download attachment
        /// </summary>
        /// <param name="taskAttachmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int taskAttachmentId)
        {
            var file = await _mediator.Send(new GetAttachmentQuery { TaskAttachmentId = taskAttachmentId });
            return File(file.Content, "application/octet-stream", file.FileName);
        }
        
    }
}

