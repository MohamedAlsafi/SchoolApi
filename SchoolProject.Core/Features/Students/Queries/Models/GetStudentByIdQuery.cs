using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Core.Features.Students.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int ID { get; set; }

        public GetStudentByIdQuery(int id)
        {
            ID = id;
            
        }

    }
}
