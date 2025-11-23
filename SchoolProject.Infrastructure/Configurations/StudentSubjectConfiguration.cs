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
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
       

            builder.HasOne(x => x.Student)
                   .WithMany(s => s.StudentSubject)
                   .HasForeignKey(x => x.StudentID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subject)
                   .WithMany(s => s.StudentsSubjects)
                   .HasForeignKey(x => x.SubjectID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

