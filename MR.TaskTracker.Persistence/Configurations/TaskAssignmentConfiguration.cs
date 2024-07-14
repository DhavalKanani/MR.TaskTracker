using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Persistence.Configurations
{
    public class TaskAssignmentConfiguration : IEntityTypeConfiguration<TaskAssignment>
    {
        public void Configure(EntityTypeBuilder<TaskAssignment> builder)
        {
            builder.HasMany(p => p.Actions)
                .WithOne(a => a.TaskAssignment)
                .HasForeignKey(p => p.TaskAssignmentId);

            builder.HasMany(p => p.Comments)
                .WithOne(a => a.TaskAssignment)
                .HasForeignKey(p => p.TaskAssignmentId);

            builder.HasMany(p => p.Attachments)
                .WithOne(a => a.TaskAssignment)
                .HasForeignKey(p => p.TaskAssignmentId);

            builder.HasOne(p => p.Assignee)
                .WithMany(p => p.TasksAssigned)
                .HasForeignKey(p => p.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Reporter)
                .WithMany(p => p.TasksReported)
                .HasForeignKey(p=>p.ReporterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
