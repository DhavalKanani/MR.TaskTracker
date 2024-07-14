using MediatR;
using MR.TaskTracker.Application.Dtos.Queries;

namespace MR.TaskTracker.Application.Features.Employees.Queries.GetApplicationUsers
{
    public class GetApplicationUserQuery : IRequest<List<ApplicationUserQueryDto>>
    {
    }
}