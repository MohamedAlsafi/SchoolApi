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
    public class AddUserHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
    {
        private readonly UserManager<User> _userManager;

        public AddUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password!= request.ConfirmPassword)
                return BadRequest<string>(LZ.Translate(SharedResourcesKeys.PasswordNotEqualConfirmPass));
            
            var existUser = await _userManager.FindByEmailAsync(request.Email);
            if (existUser!=null) 
                return BadRequest<string>(LZ.Translate(SharedResourcesKeys.EmailIsExist));

            var user = request.Map<User>();

            var createdResult = await _userManager.CreateAsync(user, request.Password);

            if (!createdResult.Succeeded)
            {
                var errors = createdResult.Errors.Select(e=>e.Description).ToList();
                return BadRequest<string>(string.Join(", ", errors));
            } 

            return Success(user.Id);
        }
    }
}
