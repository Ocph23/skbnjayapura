using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService
{
    public interface IPimpinanService
    {
        Task<IEnumerable<Pimpinan>> Get();
        Task<Pimpinan> GetById(int id);
        Task<Pimpinan> Post(Pimpinan model);
        Task<Pimpinan> Put(int id, Pimpinan model);
        Task<bool> Delete(int id);
        Task<Pimpinan> GetPimpinan(string userid);
    }
}
