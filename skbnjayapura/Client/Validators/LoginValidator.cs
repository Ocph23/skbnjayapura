using FluentValidation;
using static skbnjayapura.Client.Pages.Account.LoginPage;

namespace skbnjayapura.Client.Validators;

public class LoginValidator : AbstractValidator<Login>
{
    public LoginValidator()
    {
        RuleFor(address => address.UserName).NotEmpty();
        RuleFor(address => address.Password).NotEmpty();
    }
}
