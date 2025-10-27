using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateStudentHandeler : ResponseHandler, IRequestHandler<UpdateStudentCommand, Response<string>>
    {
        private readonly IStudentServices _services;

        public UpdateStudentHandeler(IStudentServices services)
        {
            _services = services;
        }
        public async Task<Response<string>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _services.GetById(request.ID);
            if (student is null) return NotFound<string>("Student Id not Found");

            if (request.DepartmentID == 0) request.DepartmentID = null;

            request.Map(student);

            await _services.UpdateIncludeAsync(student, nameof(student.NameEn), nameof(student.Address), nameof(student.Phone), nameof(student.DepartmentID));
            return Created("Student Updated Successfly");


        }
    }
}
