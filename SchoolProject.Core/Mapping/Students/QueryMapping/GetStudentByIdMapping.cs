using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Shared.Helper;
namespace SchoolProject.Application.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
             .ForMember(dst => dst.DepartmentName, opt => opt.MapFrom(src => src.Department.NameEn));

            CreateMap<Student, GetSingleStudentResponse>()
            .ForMember(dst => dst.DepartmentName,
                 opt => opt.MapFrom(src => LZ.LocalizeMap(src.Department.NameAr, src.Department.NameEn)));

        }
    }
}
