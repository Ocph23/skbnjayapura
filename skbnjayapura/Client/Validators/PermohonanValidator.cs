using FluentValidation;
using skbnjayapura.Shared;

namespace skbnjayapura.Client.Validators;
public class PermohonanValidator : AbstractValidator<Permohonan>
{
    public PermohonanValidator()
    {
        RuleFor(model => model.Profile).NotNull();
        RuleFor(model => model.Keperluan).NotEmpty();
        RuleFor(model => model.Catatan).NotEmpty();
        RuleFor(model => model.Keperluan).NotEmpty();
        RuleFor(model => model.TanggalPengajuan).NotNull();
    }
}