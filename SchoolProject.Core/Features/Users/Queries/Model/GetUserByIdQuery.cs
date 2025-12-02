using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Users.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Queries.Model
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdDto>>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
