using MediatR;
using School.Shared.Helper;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Wrapper;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Queries.Handelers
{
    public class GetStudentPaginatedHandler : ResponseHandler, IRequestHandler<GetStudentPaginatedQuery, PaginatedResult<GetStudentListResponse>>
    {
        private readonly IStudentServices _services;

        public GetStudentPaginatedHandler(IStudentServices services )
        {
            _services = services;
        }
        public async Task<PaginatedResult< GetStudentListResponse>> Handle(GetStudentPaginatedQuery request, CancellationToken cancellationToken)
        {
            var studentQuery = _services.GetStudentsQuery();

            studentQuery = studentQuery.ApplyFilter
                (
                   request.MinAge.HasValue ? x => x.Age >= request.MinAge.Value : null,
                   request.MaxAge.HasValue ? x => x.Age <= request.MaxAge.Value : null
                );

            var studentPaginate = await studentQuery.ProjectTo<GetStudentListResponse>()
                .ApplySearch(request.Search,x=>x.Name ,x=>x.Address ,x=>x.DepartmentName)
                .ApplyOrder(request.SortBy,request.SortDirection)
                .ToPaginatedListAsync(request.PageNumber,request.PageSize); 
            return studentPaginate;
        }



    }
}
