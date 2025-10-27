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
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
             .ForMember(dst => dst.DepartmentName, opt => opt.MapFrom(src => src.Department.NameEn));
        }
    }
}
