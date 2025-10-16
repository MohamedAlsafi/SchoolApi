using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Mapping.Students
{
    public partial class StudentProfile
    {
        public void UpdateStudentMapping()
        {
            CreateMap<UpdateStudentCommand, Student>()
                  .ForAllMembers(opts =>
                     opts.Condition((src, dest, srcMember) => srcMember != null)); ;
        }
    }
}
