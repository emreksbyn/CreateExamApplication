using CreateExam.Application.Models.Dtos;
using FluentValidation;

namespace CreateExam.Application.ValidationRules.FluentValidation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a user name");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a password");
        }
    }
}