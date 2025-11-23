using SchoolProject.Application.Features.Departement.Queries.Dtos;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department,GetDepartmentByIDQueryDto>()
                    .ForMember(d => d.ManagerName, opt => opt.MapFrom(src => src.InstructorManager != null ? src.InstructorManager.ENameEn : null))
                    .ForMember(d => d.StudentList, opt => opt.MapFrom(src => src.Students))
                    .ForMember(d => d.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects.Select(ds => ds.Subjects)))
                    .ForMember(d => d.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<Student, GetDepartmentByIDQueryDto.StudentResponse>();
            CreateMap<Subject, GetDepartmentByIDQueryDto.SubjectResponse>();
            CreateMap<Instructor, GetDepartmentByIDQueryDto.InstructorResponse>();

        }
    }
}
