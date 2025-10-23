using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Wrapper;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedQuery : IRequest<PaginatedResult<GetStudentListResponse>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 5;

        public string? Search { get; set; }

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public string? SortBy { get; set; }
        public string? SortDirection { get; set; } = "asc";


    }
}
