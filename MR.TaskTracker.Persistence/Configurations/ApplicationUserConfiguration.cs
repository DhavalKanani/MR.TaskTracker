using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var userSeed = new List<ApplicationUser> {
                new ApplicationUser {
                    Id= 1,
                    UserName ="admin@mr.tasktracker.com",
                    Email ="admin@mr.tasktracker.com",
                    Role = ApplicationUserRole.ADMIN.ToString(),
                    FirstName="A Dhaval",
                    LastName="Kanani",
                    ReportsToId=1,
                    Password = "$2a$11$ZxHBUyn3Zd9LV.hPvDj1G.KaxpVmIDRwuX2L3G3Glqq4y8Ynk3qlq",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new ApplicationUser {
                    Id= 2,
                    UserName ="user1@mr.tasktracker.com",
                    Email ="user1@mr.tasktracker.com",
                    Role = ApplicationUserRole.EMPLOYEE.ToString(),
                    FirstName="U1 Dhaval",
                    LastName="Kanani",
                    ReportsToId=1,
                    Password = "$2a$11$ZxHBUyn3Zd9LV.hPvDj1G.KaxpVmIDRwuX2L3G3Glqq4y8Ynk3qlq",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
            };
            builder.HasData(userSeed);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(20);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Role).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(50); ;
            builder.Property(p => p.ReportsToId).IsRequired();

            builder.HasOne(p => p.ReportsTo)
                .WithMany(a => a.Reports)
                .HasForeignKey(p => p.ReportsToId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}