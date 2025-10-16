using AutoMapper;
using MediatR;
using School.Shared.Helper;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Domain.Entites;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Commands.Handelers
{
    public class AddStudentHandeler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentServices _services;

        public AddStudentHandeler(IStudentServices services)
        {
            _services = services;
        }
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var stutentMapping = request.Map<Student>();
            var result = await _services.AddStudent(stutentMapping);
            //if (result == "Exist") return BadRequest<string>("Name is Exist");
             return Created("Added Successfly");
        }
    }
}
