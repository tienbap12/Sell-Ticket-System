using FluentValidation;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.User.Command.Login
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