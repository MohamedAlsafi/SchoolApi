using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            // Manager FK on Department points to Instructor.Id
         //   builder.Property(d => d.ManagerInstructorId).IsRequired(false);

            builder.HasOne(d => d.InstructorManager)
                   .WithOne(i => i.DepartmentManaged)
                   .HasForeignKey<Department>(d => d.IsManger)
                   .OnDelete(DeleteBehavior.SetNull);

            // Department -> Instructors (one-to-many)
            builder.HasMany(d => d.Instructors)
                   .WithOne(i => i.Department)
                   .HasForeignKey(i => i.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Department -> DepartmentSubjects (join table)
            builder.HasMany(d => d.DepartmentSubjects)
                   .WithOne(ds => ds.Department)
                   .HasForeignKey(ds => ds.DepartmentID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
