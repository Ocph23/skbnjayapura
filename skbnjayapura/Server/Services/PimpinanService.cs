using skbnjayapura.Server.Datas;
using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService;

public class PimpinanService : IPimpinanService
{
    private readonly ApplicationDbContext dbContext;

    public PimpinanService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }

    public Task<bool> Delete(int id)
    {
        try
        {
            var oldData = dbContext.Pimpinans.SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {
                dbContext.Pimpinans.Remove(oldData);
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

    public Task<IEnumerable<Pimpinan>> Get()
    {
        var resul = dbContext.Pimpinans.AsEnumerable();
        if (resul != null)
            return Task.FromResult(resul);

        return Task.FromResult(Enumerable.Empty<Pimpinan>());
    }

    public Task<Pimpinan> GetById(int id)
    {
        try
        {
            var oldData = dbContext.Pimpinans.SingleOrDefault(x => x.Id == id);
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

    public Task<Pimpinan> GetPimpinan(string userid)
    {
        try
        {
            var value = dbContext.Pimpinans.SingleOrDefault(x => x.UserId == userid);
            return Task.FromResult(value);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<Pimpinan> Post(Pimpinan model)
    {
        try
        {
            dbContext.Pimpinans.Add(model);
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Pimpinan> Put(int id, Pimpinan model)
    {
        try
        {
            var oldData = dbContext.Pimpinans.SingleOrDefault(x => x.Id == id);
            oldData.Name = model.Name;
            oldData.NRP = model.NRP;
            oldData.Pangkat = model.Pangkat;
            oldData.Jabatan = model.Jabatan;
            oldData.Active = model.Active;
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }
}
