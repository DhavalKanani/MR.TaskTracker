using AutoMapper;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.MappingProfiles
{
    public class TaskActionProfile : Profile
    {
        public TaskActionProfile()
        {
            CreateMap<TaskAction, TaskActionQueryDto>();
        }
    }
}
