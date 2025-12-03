using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authentication.Command.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAtUtc { get; set; }
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public IEnumerable<string> Roles { get; set; } = Array.Empty<string>();
    }
}
