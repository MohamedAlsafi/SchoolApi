using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Shared.Helper;
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
    public class GetUserPaginationHandler : ResponseHandler, IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationDto>>
    {
        private readonly UserManager<User> _userManager;

        public GetUserPaginationHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<PaginatedResult<GetUserPaginationDto>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var usersQuery = _userManager.Users.AsQueryable();   
            usersQuery = usersQuery.OrderBy(u => u.FullName);

            var paginatedList = await usersQuery
             .ApplySearch(request.Search, x => x.FullName, x => x.UserName, x => x.Address, x => x.Email)
             .ProjectTo<GetUserPaginationDto>()                     
            .ToPaginatedListAsync(request.PageNumber, request.PageSize); 
            return paginatedList;
        }
    }
}
