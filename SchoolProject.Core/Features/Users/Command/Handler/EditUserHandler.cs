using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Users.Command.Dtos;
using SchoolProject.Application.Features.Users.Command.Model;
using SchoolProject.Application.Features.Users.Queries.Dtos;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.Handler
{
    public class EditUserHandler : ResponseHandler, IRequestHandler<EditUserCommand, Response<EditUserDto>>
    {
        private readonly UserManager<User> _userManager;

        public EditUserHandler(UserManager<User> userManager )
        {
            _userManager = userManager;
        }
        public async Task<Response<EditUserDto>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return NotFound<EditUserDto>(LZ.Translate(SharedResourcesKeys.NotFound));
            request.Dto.Map(user); // ← (EditUserCommand → User)

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                var message = string.Join(" | ", errors);
                return BadRequest<EditUserDto>(message);
            }
            var dto = user.Map<EditUserDto>();  // Map the updated user back to DTO
            return Success(dto);
        }
    }
}
