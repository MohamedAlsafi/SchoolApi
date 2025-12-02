using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Shared.Helper;
using School.Shared.Resources;
using SchoolProject.Application.Features.Users.Command.Model;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Users.Command.validator
{
    public class EditUserValidator : AbstractValidator<EditUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public EditUserValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            ApplyValidationsRules();
            ApplyCustomValidationRules();
        }

        private void ApplyValidationsRules()
        {
            // FullName: only validate if provided (not null and not whitespace)
            When(x => !string.IsNullOrWhiteSpace(x.Dto?.FullName), () =>
            {
                RuleFor(x => x.Dto.FullName)
                    .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                    .MaximumLength(100).WithMessage(LZ.Translate(SharedResourcesKeys.MaxLengthis100));
            });

            // UserName: only validate format/length if provided
            When(x => !string.IsNullOrWhiteSpace(x.Dto?.UserName), () =>
            {
                RuleFor(x => x.Dto.UserName)
                    .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                    .MaximumLength(100).WithMessage(LZ.Translate(SharedResourcesKeys.MaxLengthis100));
            });

            // Email: only validate format if provided
            When(x => !string.IsNullOrWhiteSpace(x.Dto?.Email), () =>
            {
                RuleFor(x => x.Dto.Email)
                    .NotEmpty().WithMessage(LZ.Translate(SharedResourcesKeys.NotEmpty))
                    .EmailAddress().WithMessage("Invalid email format");
            });

            // PhoneNumber: only validate if provided
            When(x => !string.IsNullOrWhiteSpace(x.Dto?.PhoneNumber), () =>
            {
                RuleFor(x => x.Dto.PhoneNumber)
                    .Matches(@"^(01)[0-2,5]{1}[0-9]{8}$")
                    .WithMessage("Invalid Egyptian phone number format");
            });
        }

        private void ApplyCustomValidationRules()
        {
            // uniqueness checks only when the value is provided (non-null/non-empty)
            RuleFor(x => x.Dto.Email)
                .MustAsync(EmailNotExists)
                .WithMessage("Email is already in use.")
                .When(x => !string.IsNullOrWhiteSpace(x.Dto?.Email));

            RuleFor(x => x.Dto.UserName)
                .MustAsync(UserNameNotExists)
                .WithMessage("Username is already in use.")
                .When(x => !string.IsNullOrWhiteSpace(x.Dto?.UserName));
        }

        private async Task<bool> EmailNotExists(EditUserCommand command, string newEmail, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(newEmail)) return true;

            var user = await _userManager.FindByIdAsync(command.Id);
            if (user == null) return true;

            if (string.Equals(user.Email, newEmail, StringComparison.OrdinalIgnoreCase)) return true;

            var exists = await _userManager.FindByEmailAsync(newEmail);
            return exists == null;
        }

        private async Task<bool> UserNameNotExists(EditUserCommand command, string newUserName, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(newUserName)) return true;

            var user = await _userManager.FindByIdAsync(command.Id);
            if (user == null) return true;

            if (string.Equals(user.UserName, newUserName, StringComparison.OrdinalIgnoreCase)) return true;

            var exists = await _userManager.FindByNameAsync(newUserName);
            return exists == null;
        }
    }

}
