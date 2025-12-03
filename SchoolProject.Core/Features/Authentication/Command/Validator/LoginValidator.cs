using FluentValidation;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Features.Authentication.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authentication.Command.Validator
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            ApplyValidationsRules();

        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                .NotNull().WithMessage(LZ.Translate(SharedResourcesKeys.Required));
        }
    }
}
