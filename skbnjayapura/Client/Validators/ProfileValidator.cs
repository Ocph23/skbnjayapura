using FluentValidation;
using skbnjayapura.Shared;

namespace skbnjayapura.Client.Validators;
public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(model => model.Nama).NotEmpty();
        RuleFor(model => model.Kebangsaan).NotEmpty();
        RuleFor(model => model.JenisKelamin).NotEmpty();
        RuleFor(model => model.Agama).NotEmpty();
        RuleFor(model => model.Pekerjaan).NotEmpty();
        RuleFor(model => model.TempatLahir).NotEmpty();
        RuleFor(model => model.TanggalLahir).NotEmpty();
        RuleFor(model => model.Alamat).NotEmpty();
        RuleFor(model => model.NomorHP).NotEmpty();
    }
}