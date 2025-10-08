using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handelers
{
    public class GetStudentListHandeler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        private readonly IStudentServices _studentServices;
        

        public GetStudentListHandeler(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
          return await _studentServices.GetStudentsListasync();
            
        }
    }
}
