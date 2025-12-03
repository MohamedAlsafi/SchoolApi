using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authentication.Command.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authentication.Command.Model
{
    public class LoginCommand : IRequest<Response<LoginResponseDto>>
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; }="";
    }
}
