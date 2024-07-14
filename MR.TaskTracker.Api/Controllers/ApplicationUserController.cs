using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Features.Employees.Queries.GetApplicationUsers;

namespace MR.TaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Employee
        /// <summary>
        /// return All employees for assigning task, self and who reports to current loggedin user
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<ApplicationUserQueryDto>>> Get()
        {
            var employeeQuery = await _mediator.Send(new GetApplicationUserQuery());
            return Ok(employeeQuery);
        }
    }
}

