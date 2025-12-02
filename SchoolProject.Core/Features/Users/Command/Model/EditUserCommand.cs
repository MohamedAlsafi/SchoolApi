using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Users.Command.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.Model
{
    public record EditUserCommand(string Id, EditUserDto Dto): IRequest<Response<EditUserDto>>;

    //public class EditUserCommand : IRequest<Response<EditUserDto>>
    //{
    //    public string Id { get; set; }
    //    public string FullName { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public string? Address { get; set; }
    //    public string? Country { get; set; }
    //    public string? PhoneNumber { get; set; }
    //}
}
