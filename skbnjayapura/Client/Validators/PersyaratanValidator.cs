using FluentValidation;
using skbnjayapura.Shared;

namespace skbnjayapura.Client.Validators;

public class PersyaratanValidator : AbstractValidator<Persyaratan>
{
    public PersyaratanValidator()
    {
        RuleFor(x => x.Nama).NotEmpty();
        RuleFor(x => x.Keterangan).NotEmpty();
    }
}
