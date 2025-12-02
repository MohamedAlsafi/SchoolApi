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
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
       
        public ChangeUserPasswordValidator()
        {
            ApplyValidationsRules();
          
        }
        
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                   .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                   .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));

            RuleFor(x => x.CurrentPassword)
                 .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                 .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));
            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                 .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.NewPassword).WithMessage(LZ.Translate(SharedResourcesKeys.PasswordNotEqualConfirmPass));


        }
    }
}
