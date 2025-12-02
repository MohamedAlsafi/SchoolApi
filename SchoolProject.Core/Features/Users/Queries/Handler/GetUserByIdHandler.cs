using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Users.Queries.Dtos;
using SchoolProject.Application.Features.Users.Queries.Model;
using SchoolProject.Application.Wrapper;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Queries.Handler
{
    public class GetUserByIdHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery, Response<GetUserByIdDto>>
    {
        private readonly UserManager<User> _userManager;

        public GetUserByIdHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
      

        public async Task<Response<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            
              if (user is null) return NotFound<GetUserByIdDto>(LZ.Translate(SharedResourcesKeys.NotFound));

            var mappingResult = user.Map<GetUserByIdDto>();
            return Success(mappingResult);
        }
    }
}
