using SchoolProject.Application.Features.Users.Queries.Dtos;
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
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdDto>();

        }
    }
}
