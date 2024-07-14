using AutoMapper;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.MappingProfiles
{
    public class TaskAssignmentProfile : Profile
    {
        public TaskAssignmentProfile()
        {
            CreateMap<TaskAssignment, TaskAssignmentQueryDto>();
            CreateMap<TaskAssignmentCommandDto, TaskAssignment>();
            CreateMap<TaskAssignmentCommandDto, TaskAssignmentQueryDto>();
        }
    }
}
