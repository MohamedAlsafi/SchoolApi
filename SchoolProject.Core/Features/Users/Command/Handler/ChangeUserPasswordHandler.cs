using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Users.Command.Model;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.Handler
{
    public class ChangeUserPasswordHandler : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public ChangeUserPasswordHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return NotFound<string>(LZ.Translate(SharedResourcesKeys.NotFound));

            var result = await _userManager.ChangePasswordAsync(user,request.CurrentPassword,request.NewPassword);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest<string>(string.Join(", ", errors));
            }
            return Success((string)LZ.Translate(SharedResourcesKeys.PasswordChangedSuccessfully));
        }
    }
}
