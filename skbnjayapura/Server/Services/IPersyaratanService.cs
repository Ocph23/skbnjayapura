using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService
{
    public interface IPersyaratanService
    {
        Task<IEnumerable<Persyaratan>> Get();
        Task<Persyaratan> GetById(int id);
        Task<Persyaratan> Post(Persyaratan model);
        Task<Persyaratan> Put(int id, Persyaratan model);
        Task<bool> Delete(int id);

    }
}
