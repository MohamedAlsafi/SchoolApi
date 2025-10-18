using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Commands.Handelers
{
    public class DeleteStudentHandler : ResponseHandler, IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentServices _services;

        public DeleteStudentHandler(IStudentServices services)
        {
            _services = services;
        }
        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _services.GetById(request.Id);
            if (student is null)
                return NotFound<string>("Student not found");

            await _services.DeleteStudent(student);
            return Success("Student deleted successfully");
        }
    }
}
