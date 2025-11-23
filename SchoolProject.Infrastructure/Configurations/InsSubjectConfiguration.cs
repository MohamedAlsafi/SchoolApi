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
    public class InsSubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasOne(x => x.instructor)
                   .WithMany(i => i.Ins_Subjects)
                   .HasForeignKey(x => x.InstructorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subject)
                   .WithMany(s => s.Ins_Subjects)
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
