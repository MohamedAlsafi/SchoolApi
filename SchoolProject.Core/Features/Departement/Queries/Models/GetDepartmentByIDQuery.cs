using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Departement.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Departement.Queries.Models
{
    public class GetDepartmentByIDQuery : IRequest<Response<GetDepartmentByIDQueryDto>>
    {
        public GetDepartmentByIDQuery(int id )
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
