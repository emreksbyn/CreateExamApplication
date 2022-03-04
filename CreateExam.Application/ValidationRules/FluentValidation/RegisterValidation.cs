using CreateExam.Application.Models.Dtos;
using FluentValidation;

namespace CreateExam.Application.ValidationRules.FluentValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Name can't be empty")
                .MinimumLength(3).MaximumLength(10).WithMessage("Min 3, Max 10 character");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Lastname can't be empty")
                .Length(3, 15).WithMessage("Min 3, Max 15 character");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name can't be empty")
                .Length(3, 12).WithMessage("Min 3, Max 12 character");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Enter a email adress")
                .EmailAddress().WithMessage("Enter a valid email address");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Enter a password");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Enter a password again")
                .Equal(x => x.Password).WithMessage("Password don't match");
        }
    }
}