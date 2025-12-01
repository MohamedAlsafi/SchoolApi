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
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>()
                    .ForMember(d => d.Id, opt => opt.Ignore())
                    .ForMember(d => d.PasswordHash, opt => opt.Ignore()); ;
        }
    }
}
