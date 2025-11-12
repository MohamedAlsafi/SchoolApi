using MediatR;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Response
{
    public class GetStudentListResponse 
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }

        public string ? Address { get; set; }
      
        public string? Phone { get; set; }
        public string? DepartmentName { get; set; }
    }
}
