using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authentication.Command.Dtos;
using SchoolProject.Application.Features.Authentication.Command.Model;
using SchoolProject.Infrastructure.Identity;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authentication.Command.Handler
{
    public class LoginHandler : ResponseHandler, IRequestHandler<LoginCommand, Response<LoginResponseDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginHandler(UserManager<User> userManager , SignInManager<User> signInManager , IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<Response<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                return Unauthorized<LoginResponseDto>(LZ.Translate(SharedResourcesKeys.UserNameIsNotExist));
            }

            // Check password (uses lockout if configured)
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if (!signInResult.Succeeded)
            {
                return Unauthorized<LoginResponseDto>(LZ.Translate(SharedResourcesKeys.PasswordNotCorrect));
            }

            // Get roles
            var roles = await _userManager.GetRolesAsync(user);

            // Create token
            var token = _jwtTokenService.GenerateToken(user, roles);
            var expiry = _jwtTokenService.GetExpiryUtc();

            var dto = new LoginResponseDto
            {
                Token = token,
                ExpiresAtUtc = expiry,
                UserId = user.Id.ToString(),
                UserName = user.UserName ?? "",
                Roles = roles
            };

            return Success(dto);
        }
    }
}
