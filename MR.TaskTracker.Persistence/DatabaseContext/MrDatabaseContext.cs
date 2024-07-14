using MR.TaskTracker.Domain;
using MR.TaskTracker.Domain.Common;
using MR.TaskTracker.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR.TaskTracker.Persistence.DatabaseContext
{
    public class MrDatabaseContext : DbContext
    {
        public MrDatabaseContext(DbContextOptions<MrDatabaseContext> options) : base(options)
        {

        }

        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskAction> TaskActions { get; set; }
        public DbSet<TaskAttachment> TaskComments { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MrDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            foreach (var entry in base.ChangeTracker.Entries<TaskAssignment>().Where(q => q.State == EntityState.Modified))
            {
                if (entry.Property(nameof(TaskAssignment.CurrentStatus)).IsModified)
                {
                    TaskActions.Add(new TaskAction
                    {
                        TaskAssignmentId = (int)entry.OriginalValues[nameof(TaskAssignment.Id)],
                        FromStatus = (string)entry.OriginalValues[nameof(TaskAssignment.CurrentStatus)],
                        ToStatus = (string)entry.CurrentValues[nameof(TaskAssignment.CurrentStatus)],
                    }) ;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
