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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

            builder.HasMany(s => s.Ins_Subjects)
                   .WithOne(isub => isub.Subject)
                   .HasForeignKey(isub => isub.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.DepartmetsSubjects)
                   .WithOne(ds => ds.Subjects)
                   .HasForeignKey(ds => ds.SubjectID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.StudentsSubjects)
                   .WithOne(ss => ss.Subject)
                   .HasForeignKey(ss => ss.SubjectID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
