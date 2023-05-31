using FluentValidation;
using static skbnjayapura.Client.Pages.Account.RegisterPage;

namespace skbnjayapura.Client.Validators;
public class RegisterValidator : AbstractValidator<Register>
{
    public RegisterValidator()
    {
        RuleFor(address => address.Email).NotEmpty().EmailAddress();
        RuleFor(address => address.Password).NotEmpty();
        RuleFor(address => address.ConfirmPassword).NotEmpty().Equal(x => x.Password);
    }
}