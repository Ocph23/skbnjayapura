using FluentValidation;
using skbnjayapura.Shared;

namespace skbnjayapura.Client.Validators;

public class SKBNValidator : AbstractValidator<SKBN>
{
    public SKBNValidator()
    {
        RuleFor(x => x.Nomor).NotEmpty();
        RuleFor(x => x.NomorSKPN).NotEmpty();
        RuleFor(x => x.TanggalSKPN).NotEmpty();
        RuleFor(x => x.BerlakuMulai).NotEmpty().GreaterThanOrEqualTo(x=>x.TanggalSKPN);
        RuleFor(x => x.BerlakuSelesai).NotEmpty().GreaterThan(x=>x.BerlakuMulai);
        RuleFor(x => x.TanggalPersetujuan).NotEmpty();
    }
}
