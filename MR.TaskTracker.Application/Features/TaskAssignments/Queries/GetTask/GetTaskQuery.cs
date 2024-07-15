using MediatR;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetTask
{
    public class GetTaskAssignmentQuery : IRequest<TaskAssignmentQueryDto>
	{
        public int Id { get; set; }
    }
}

