using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class DeleteUserHandler : ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return NotFound<string>("User Not Found");
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded) return BadRequest<string>(LZ.Translate(SharedResourcesKeys.DeletedFailed));
            return Success((string)LZ.Translate(SharedResourcesKeys.Deleted));
        }
    }
}
