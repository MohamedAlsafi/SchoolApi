using MediatR;
using SchoolProject.Application.Features.Users.Queries.Dtos;
using SchoolProject.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Queries.Model
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? Search { get; set; }
    }
}
