using AutoMapper;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Dtos.Command;
using MR.TaskTracker.Domain;
using MR.TaskTracker.Application.Models.File;

namespace MR.TaskTracker.Application.MappingProfiles
{
    public class TaskAttachmentProfile : Profile
    {
        public TaskAttachmentProfile()
        {
            CreateMap<TaskAttachment, TaskAttachmentQueryDto>();
            // CreateMap<TaskAttachmentCommandDto, TaskAttachmentQueryDto>();
            CreateMap<TaskAttachmentCommandDto, TaskAttachment>();
            CreateMap<TaskAttachment, FileModel>();
        }
    }
}
