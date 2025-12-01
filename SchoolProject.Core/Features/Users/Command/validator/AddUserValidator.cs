using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Features.Users.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.validator
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
       
        public AddUserValidator()
        {
            ApplyValidationsRules();
          
        }
        
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                 .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required))
                 .MaximumLength(100).WithMessage(LZ.Translate(SharedResourcesKeys.MaxLengthis100));

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required))
                .MaximumLength(100).WithMessage(LZ.Translate(SharedResourcesKeys.MaxLengthis100));

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                 .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                 .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(LZ.Translate(SharedResourcesKeys.PasswordNotEqualConfirmPass));

        }   
    }
}
