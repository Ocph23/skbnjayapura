using skbnjayapura.Shared;

namespace skbnjayapura.Server.Services.AuthService
{
    public interface IPermohonanService
    {
        Task<IEnumerable<Permohonan>> Get();
        Task<Permohonan> GetById(int id);
        Task<Permohonan> Post(Permohonan model);
        Task<Permohonan> Put(int id, Permohonan model);
        Task<bool> Delete(int id);
        Task<ItemPersyaratan> GetItemPersyaratan(int id);
        Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan itemPersyaratan);
        IEnumerable<Permohonan> GetByProfile(int id);
        Task<bool> VerifikasiPersyaratan(ItemPersyaratan model);
        IEnumerable<SKBNModel> GetSKBN();
    }
}
