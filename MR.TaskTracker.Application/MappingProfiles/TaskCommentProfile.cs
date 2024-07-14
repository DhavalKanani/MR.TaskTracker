using AutoMapper;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.MappingProfiles
{
    public class TaskCommentProfile : Profile
    {
        public TaskCommentProfile()
        {
            CreateMap<TaskComment, TaskCommentQueryDto>();
            CreateMap<TaskCommentCommandDto, TaskCommentQueryDto>();
            CreateMap<TaskCommentCommandDto, TaskComment>();
        }
    }
}
