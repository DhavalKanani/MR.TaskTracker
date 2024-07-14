using MR.TaskTracker.Application.Contracts.Persistence;
using MR.TaskTracker.Persistence.DatabaseContext;
using MR.TaskTracker.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MR.TaskTracker.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MrDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MrDatabaseConnectionString"));
        }, ServiceLifetime.Scoped);

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
        services.AddScoped<ITaskAssignmentRepository, TaskAssignmentRepository>();
        services.AddScoped<ITaskCommentRepository, TaskCommentRepository>();
        services.AddScoped<ITaskAttachmentRepository, TaskAttachmentRepository>();

        return services;
    }
}
