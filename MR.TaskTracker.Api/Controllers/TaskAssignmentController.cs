using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.CreateTaskAssignment;
using MR.TaskTracker.Application.Features.TaskAssignments.Commands.UpdateTaskAssignment;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments;
using MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetTask;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MR.TaskTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TaskAssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskAssignmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/TaskAssignment
    /// <summary>
    /// Returns all Task based on three filter criteria and record visiblity
    /// </summary>
    /// <param name="assigneeId"></param>
    /// <param name="reporterId"></param>
    /// <param name="dueDate"></param>
    [HttpGet]
    public async Task<ActionResult<List<TaskAssignmentQueryDto>>> Get([FromQuery]int? assigneeId, [FromQuery] int? reporterId, [FromQuery] DateTimeOffset? dueDate)
    {
        var taskAssignments = await _mediator.Send(new GetAllTaskAssignmentsQuery() {
                                                        AssigneeId = assigneeId,
                                                        ReporterId = reporterId,
                                                        DueDate = dueDate
                                                    });
        return Ok(taskAssignments);
    }

    // GET api/TaskAssignment/5
    /// <summary>
    /// Get Task with dependent records
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskAssignmentQueryDto>> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetTaskAssignmentQuery() { Id = id });
        return Ok(leaveRequest);
    }

    // POST api/<LeaveRequestsController>
    /// <summary>
    /// Create task and use get employee api to get assignee details
    /// </summary>
    /// <param name="taskAssignment"></param>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateTaskAssignmentCommand taskAssignment)
    {
        var response = await _mediator.Send(taskAssignment);
        return CreatedAtAction(nameof(Get), response.Id);
    }

    // PUT api/<LeaveRequestsController>/5
    /// <summary>
    /// update task Status or StoryPoint 
    /// </summary>
    /// <param name="taskAssignment"></param>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTaskAssignmentCommand taskAssignment)
    {
        await _mediator.Send(taskAssignment);
        return NoContent();
    }
}
