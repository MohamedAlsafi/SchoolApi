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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            // Self-reference: Supervisor -> Subordinates
            builder.HasOne(i => i.Supervisor)
                   .WithMany(i => i.Subordinates)
                   .HasForeignKey(i => i.SupervisorId)
                   .OnDelete(DeleteBehavior.Restrict); 

            // Instructor -> Department (many-to-one: membership)
            builder.HasOne(i => i.Department)
                   .WithMany(d => d.Instructors)
                   .HasForeignKey(i => i.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);


            // Instructor -> InsSubjects (one-to-many from Instructor to join table)
            builder.HasMany(i => i.Ins_Subjects)
                   .WithOne(x => x.instructor)
                   .HasForeignKey(x => x.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
