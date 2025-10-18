using FluentValidation;
using SchoolProject.Application.Features.Students.Commands.Models;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Commands.validator
{
    public class UpdateStudentCommandValidator  : AbstractValidator<UpdateStudentCommand>   
    {
        private readonly IStudentServices _services;

        public UpdateStudentCommandValidator (IStudentServices services)
        {
            _services = services;
            ValidateEntity();
           
        }

        private void ValidateEntity()
        {

            RuleFor(X => X.Name)

                .NotEmpty().WithMessage("Name must Not be Empty ")
                .MinimumLength(3).WithMessage("Minimum Length is 3 ")
                .When(x => !string.IsNullOrEmpty(x.Name) && x.Name != "string");
               
            RuleFor(x => x.Address)
                .MaximumLength(30).WithMessage("Maximum Length is 30")
                .When(x => !string.IsNullOrEmpty(x.Address) && x.Address != "string");


            RuleFor(x => x.Phone)
             .Length(11)
             .WithMessage("phone number must be 11 digits")
             .When(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone != "string");


            RuleFor(x => x.DepartmentID)
             .GreaterThan(0)
             .When(x => x.DepartmentID.HasValue && x.DepartmentID.Value != 0)
             .WithMessage("DepartmentId must be greater than 0");



        }


    }
}
