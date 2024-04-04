using FluentValidation;
using ST.Application.Commons.Errors;

namespace ST.Application.Feature.User.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Request.userName)
                .NotEmpty().WithMessage(ValidationErrors.General.IsRequired("Username"));

            RuleFor(x => x.Request.Password)
                .NotEmpty().WithMessage(ValidationErrors.General.IsRequired("Password"));
        }
    }
}
