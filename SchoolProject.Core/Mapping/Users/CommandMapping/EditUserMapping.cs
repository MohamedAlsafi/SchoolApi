using SchoolProject.Application.Features.Users.Command.Dtos;
using SchoolProject.Application.Features.Users.Command.Model;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserDto, User>()
       .ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
           srcMember != null
           && !(srcMember is string s && string.IsNullOrWhiteSpace(s))
           && !(srcMember is string s2 && s2 == "string") 
       ));

            CreateMap<User, EditUserDto>();

        }
    }
}
