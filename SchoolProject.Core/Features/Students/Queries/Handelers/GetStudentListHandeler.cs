using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handelers
{
    public class GetStudentListHandeler : IRequestHandler<GetStudentListQuery, List<GetStudentListResponse>>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public GetStudentListHandeler(IStudentServices studentServices , IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }
        

        public async Task<List<GetStudentListResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentServices.GetStudentsListasync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return studentListMapper;
        }
    }
}
