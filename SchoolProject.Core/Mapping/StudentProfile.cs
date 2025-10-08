using AutoMapper;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student,GetStudentListResponse>()
                .ForMember(dst=>dst.DepartmentName,opt=> opt.MapFrom(src=>src.Department.Name));
        }
    }
}
