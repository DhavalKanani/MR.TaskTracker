using AutoMapper;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Models.Identity;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.MappingProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserQueryDto>();
            CreateMap<ApplicationUser, ApplicationUserModel>();
        }
    }
}