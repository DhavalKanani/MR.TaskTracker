using MediatR;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.TaskAssignments.Queries.GetAllTaskAssignments
{
    public class GetAllTaskAssignmentsQuery : IRequest<List<TaskAssignmentQueryDto>>
    {
        public int? AssigneeId { get; set; }
        public int? ReporterId { get; set; }
        public DateTimeOffset? DueDate { get; set; }
    }
}


