using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> Get();
        Task<Profile> GetById(int id);
        Task<Profile> Post(Profile model);
        Task<Profile> Put(int id, Profile model);
        Task<bool> Delete(int id);

    }
}
