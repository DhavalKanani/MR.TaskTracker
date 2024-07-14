using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MR.TaskTracker.Application.Contracts.Identity;
using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Application.Dtos.Queries;
using MR.TaskTracker.Application.Models.Identity;

namespace MR.TaskTracker.Identity.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public UserService(IApplicationUserRepository applicationUserRepository, IHttpContextAccessor contextAccessor,IMapper mapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<ApplicationUserModel> GetUserFromContext()
        {
            int userId = int.Parse(_contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Actor));
            var user = await _applicationUserRepository.GetByIdAsync(userId);
            return _mapper.Map<ApplicationUserModel>(user);
        }
    }
}

