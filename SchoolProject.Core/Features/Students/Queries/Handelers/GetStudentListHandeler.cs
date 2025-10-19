using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Shared.Helper;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Wrapper;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handelers
{
    public class GetStudentListHandeler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<PaginatedResult<GetStudentListResponse>>>
    {
        private readonly IStudentServices _studentServices;


        public GetStudentListHandeler(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        

        //public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        //{
        //    var studentQuery = _studentServices.GetStudentsQuery();
        //    var studentList = await studentQuery.ProjectTo<GetStudentListResponse>().ToListAsync(cancellationToken);
        //    return Success(studentList);
        //}

        public async Task<Response<PaginatedResult<GetStudentListResponse>>> Handle(GetStudentListQuery request,CancellationToken cancellationToken)
        {
            var studentQuery = _studentServices.GetStudentsQuery();

            var pagedStudents = await studentQuery
                .ProjectTo<GetStudentListResponse>()
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            //return Response<PaginatedResult<GetStudentListResponse>>.Success(pagedStudents);
            return new Response<PaginatedResult<GetStudentListResponse>>(pagedStudents, "Success");

        }
    }
}
