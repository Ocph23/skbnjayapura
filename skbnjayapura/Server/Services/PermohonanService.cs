using Microsoft.EntityFrameworkCore;
using skbnjayapura.Server.Datas;
using skbnjayapura.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace skbnjayapura.Server.Services.AuthService;

public class PermohonanService : IPermohonanService
{
    private readonly ApplicationDbContext dbContext;

    public PermohonanService(ApplicationDbContext _dbContext)
    {
        dbContext = _dbContext;
    }
    public Task<bool> Delete(int id)
    {
        try
        {
            var oldData = dbContext.Permohonans.SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {
                dbContext.Permohonans.Remove(oldData);
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

    public Task<IEnumerable<Permohonan>> Get()
    {
        var resul = dbContext.Permohonans
                .Include(x => x.Profile)
                .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan).AsEnumerable();
        return Task.FromResult(resul is null ? Enumerable.Empty<Permohonan>() : resul);
    }

    public Task<Permohonan> GetById(int id)
    {
        try
        {
            var oldData = dbContext.Permohonans
                .Include(x => x.Profile)
                .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan)
                .SingleOrDefault(x => x.Id == id);
            if (oldData != null)
            {

                var persyaratans = dbContext.Persyaratans.AsEnumerable();
                var result = persyaratans.Where(x => !oldData.ItemPersyaratan.Any(p => p.Persyaratan.Id == x.Id));
                foreach (var item in result)
                {
                    dbContext.Entry(item).State = EntityState.Unchanged;
                    oldData.ItemPersyaratan.Add(new ItemPersyaratan { Persyaratan = item });
                }
                dbContext.SaveChanges();
                return Task.FromResult(oldData);
            }
            throw new SystemException("Data Tidak Ditemukan !");
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public IEnumerable<Permohonan> GetByProfile(int id)
    {
        var oldData = dbContext.Permohonans
                .Include(x => x.Profile)
                .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan)
                .Where(x => x.Profile.Id == id).AsEnumerable();

        return oldData is null ? Enumerable.Empty<Permohonan>() : oldData;
    }

    public Task<ItemPersyaratan> GetItemPersyaratan(int id)
    {
        var result = dbContext.Permohonans
               .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan)
               .SelectMany(x => x.ItemPersyaratan).FirstOrDefault(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(result);
        return Task.FromResult(result);
    }

    public IEnumerable<SKBNModel> GetSKBN()
    {
        var data = from a in dbContext.Permohonans
                .Include(x => x.Profile)
                .Include(x => x.Skbn).Where(x => x.Skbn != null)
                   select new SKBNModel(a.Skbn.Id, a.Skbn.NomorView, a.Profile, a.Skbn.NomorSKPN, a.Skbn.TanggalSKPN.Value,
                   a.Keperluan, a.Skbn.BerlakuMulai.Value,
                   a.Skbn.BerlakuSelesai.Value,
                   a.Skbn.TanggalPersetujuan.Value,a.Skbn.TangglPengambilan, a.Skbn.DiambilOleh);
        if(!data.Any())
            return Enumerable.Empty<SKBNModel>();
        return data.AsEnumerable();

    }

    public Task<Permohonan> Post(Permohonan model)
    {
        try
        {
            var persyaratans = dbContext.Persyaratans.Where(x => x.Aktif);
            if (persyaratans.Any())
            {
                foreach (var item in persyaratans)
                {
                    model.ItemPersyaratan.Add(new ItemPersyaratan { Persyaratan = item });
                }
            }

            dbContext.Entry(model.Profile).State = EntityState.Unchanged;
            dbContext.Permohonans.Add(model);
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Pengambilan> PostPengambilan(Pengambilan value)
    {
        try
        {
            var oldData = dbContext.Permohonans
                .Include(x => x.Skbn).Where(x => x.Skbn != null && x.Skbn.Id == value.Id).FirstOrDefault();

            oldData.Status = StatusPermohonan.Diambil;
            oldData.Skbn.DiambilOleh = value.Nama;
            oldData.Skbn.TangglPengambilan = value.Tanggal;
            dbContext.SaveChanges();
            return Task.FromResult(value);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<Permohonan> Put(int id, Permohonan model)
    {
        try
        {
            var oldData = dbContext.Permohonans
                .Include(x => x.Skbn)
                .Include(x => x.Profile)
                .SingleOrDefault(x => x.Id == id);

            dbContext.Entry(oldData.Profile).State = EntityState.Unchanged;
            dbContext.Entry(oldData).CurrentValues.SetValues(model);

            if (model.Skbn != null)
            {
                oldData.Skbn = model.Skbn;
            }
            dbContext.SaveChanges();
            return Task.FromResult(model);
        }
        catch (Exception ex)
        {
            throw new SystemException(ex.Message);
        }
    }

    public Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan model)
    {
        var data = (from a in dbContext.Permohonans
                 .Include(x => x.Profile)
                 .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan)
                    from b in a.ItemPersyaratan.Where(x => x.Id == model.Id)
                    select new { a.Profile, b }).FirstOrDefault();

        if (data is not null)
        {
            dbContext.Entry(data.b).CurrentValues.SetValues(model);
            if (!string.IsNullOrEmpty(model.FileName) && data.b.Persyaratan.IsPhoto)
            {
                data.Profile.Photo = model.FileName;
            }
            dbContext.SaveChanges();
        }
        return Task.FromResult(model!);
    }

    public Task<bool> VerifikasiPersyaratan(ItemPersyaratan model)
    {

        var datax = (from a in dbContext.Permohonans
                .Include(x => x.Profile)
                .Include(x => x.ItemPersyaratan).ThenInclude(x => x.Persyaratan)
                     from b in a.ItemPersyaratan.Where(x => x.Id == model.Id)
                     select new { a, b }).FirstOrDefault();

        ArgumentNullException.ThrowIfNull(datax, "Data tidak ditemukan !");
        datax.b.Verifikasi = model.Verifikasi;

        if (datax.a.Status == StatusPermohonan.Baru || datax.a.Status == StatusPermohonan.Verifikasi)
        {
            if (datax.a.Status == StatusPermohonan.Baru &&
                datax.a.ItemPersyaratan != null
                && datax.a.ItemPersyaratan.Count(x => !x.Verifikasi) <= 0)
            {
                datax.a.Status = StatusPermohonan.Verifikasi;
            }
            else if (datax.a.Status == StatusPermohonan.Verifikasi &&
                datax.a.ItemPersyaratan != null
                && datax.a.ItemPersyaratan.Count(x => !x.Verifikasi) > 0)
            {
                datax.a.Status = StatusPermohonan.Baru;
            }
        }
        else
        {
            throw new SystemException($"Maaf Anda Tidak Mengubah Data. Status Permohonan : '{datax.a.Status}' ");
        }

        dbContext.SaveChanges();




        return Task.FromResult(true);
    }
}
