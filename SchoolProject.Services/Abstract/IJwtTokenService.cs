using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, IEnumerable<string> roles);
        DateTime GetExpiryUtc();

    }
}
