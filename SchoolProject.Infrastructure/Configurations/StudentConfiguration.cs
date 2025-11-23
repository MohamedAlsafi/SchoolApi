using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            

            builder.HasOne(s => s.Department)
                   .WithMany(d => d.Students)
                   .HasForeignKey(s => s.DepartmentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentSubject)
                   .WithOne(ss => ss.Student)
                   .HasForeignKey(ss => ss.StudentID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
