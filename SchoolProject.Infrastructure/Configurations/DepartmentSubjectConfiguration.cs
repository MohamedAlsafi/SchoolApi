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
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
         

            builder.HasOne(x => x.Department)
                   .WithMany(d => d.DepartmentSubjects)
                   .HasForeignKey(x => x.DepartmentID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subjects)
                   .WithMany(s => s.DepartmetsSubjects)
                   .HasForeignKey(x => x.SubjectID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
