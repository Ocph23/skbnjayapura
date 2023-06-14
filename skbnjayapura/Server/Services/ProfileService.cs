using skbnjayapura.Server.Datas;
using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService;

public class ProfileService : IProfileService
{
    private readonly ApplicationDbContext dbContext;

    public ProfileService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public Task<bool> Delete(int id)
    {
        try
        {
            var oldData = dbContext.Profiles.SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {
                dbContext.Profiles.Remove(oldData);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<IEnumerable<Profile>> Get()
    {
        var resul = dbContext.Profiles.AsEnumerable();
        if (resul != null)
            return Task.FromResult(resul);

        return Task.FromResult(Enumerable.Empty<Profile>());
    }

    public Task<Profile> GetById(int id)
    {
        try
        {
            var oldData = dbContext.Profiles.SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {
                return Task.FromResult(oldData);
            }
            throw new SystemException("Data Tidak Ditemukan !");
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Profile> Post(Profile model)
    {
        try
        {
            dbContext.Profiles.Add(model);
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Profile> Put(int id, Profile model)
    {
        try
        {
            var oldData = dbContext.Profiles.SingleOrDefault(x => x.Id == id);

            oldData.NomorHP= model.NomorHP;
            oldData.NomorNIK= model.NomorNIK;
            oldData.Nama= model.Nama;
            oldData.Aktif= model.Aktif;
            oldData.Alamat= model.Alamat;
            oldData.Agama= model.Agama;
            oldData.JenisKelamin= model.JenisKelamin;
            oldData.Kebangsaan= model.Kebangsaan;
            oldData.Pekerjaan= model.Pekerjaan;
            oldData.TanggalLahir= model.TanggalLahir;
            oldData.TempatLahir= model.NomorHP;
            oldData.Photo= model.Photo;
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }
}
