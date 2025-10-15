using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Shared.Helper;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handelers
{
    public class GetStudentByIdtHandeler : ResponseHandler, IRequestHandler<GetStudentByIdQuery,Response<GetSingleStudentResponse>>
    {
        private readonly IStudentServices _studentServices;


        public GetStudentByIdtHandeler(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student =  _studentServices.GetStudentById(request.ID);
            var studentMapping = await student.ProjectTo<GetSingleStudentResponse>().FirstOrDefaultAsync(cancellationToken);
            if (studentMapping is null)
            {
                return NotFound<GetSingleStudentResponse>("Student Not Found");
            }
            return Success (studentMapping);
        }
    }
}
