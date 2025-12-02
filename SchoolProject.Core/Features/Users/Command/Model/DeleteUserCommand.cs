using MediatR;
using SchoolProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.Model
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            Id = id;
            
        }
    }
}
