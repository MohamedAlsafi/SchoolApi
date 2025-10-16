using MediatR;
using SchoolProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Commands.Models
{
    public class UpdateStudentCommand : IRequest<Response<string>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? DepartmentID { get; set; }
    }
}
