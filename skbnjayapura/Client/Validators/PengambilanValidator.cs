using FluentValidation;
using skbnjayapura.Shared;

namespace skbnjayapura.Client.Validators;

public class PengambilanValidator : AbstractValidator<Pengambilan>
{
    public PengambilanValidator()
    {
        RuleFor(x => x.Nama).NotEmpty();
        RuleFor(x => x.Tanggal).NotNull();
    }
}
