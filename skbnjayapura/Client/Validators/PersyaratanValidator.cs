using FluentValidation;
using skbnjayapura.Shared;
using static skbnjayapura.Client.Pages.Account.LoginPage;

namespace skbnjayapura.Client.Validators;

public class PersyaratanValidator : AbstractValidator<Persyaratan>
{
    public PersyaratanValidator()
    {
        RuleFor(x => x.Nama).NotEmpty();
        RuleFor(x => x.Keterangan).NotEmpty();
    }
}
