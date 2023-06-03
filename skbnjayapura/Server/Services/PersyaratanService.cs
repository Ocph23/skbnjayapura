using skbnjayapura.Server.Datas;
using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService;

public class PersyaratanService : IPersyaratanService
{
    private readonly ApplicationDbContext dbContext;

    public PersyaratanService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public Task<bool> Delete(int id)
    {
        try
        {
            var oldData = dbContext.Persyaratans.SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {
                dbContext.Persyaratans.Remove(oldData);
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

    public Task<IEnumerable<Persyaratan>> Get()
    {
        var resul = dbContext.Persyaratans.AsEnumerable();
        if (resul != null)
            return Task.FromResult(resul);

        return Task.FromResult(Enumerable.Empty<Persyaratan>());
    }

    public Task<Persyaratan> GetById(int id)
    {
        try
        {
            var oldData = dbContext.Persyaratans.SingleOrDefault(x => x.Id == id);
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

    public Task<Persyaratan> Post(Persyaratan model)
    {
        try
        {
            dbContext.Persyaratans.Add(model);
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Persyaratan> Put(int id, Persyaratan model)
    {
        try
        {
            var oldData = dbContext.Persyaratans.SingleOrDefault(x => x.Id == id);
            dbContext.Entry(oldData).CurrentValues.SetValues(model);
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }
}
