using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public class Permohoan
    {
        public int Id { get; set; }
        public Profile? Profile { get; set; }
        public string? Keperluan { get; set; }= string.Empty;
        public DateTime? TanggalPengajuan { get; set; } = DateTime.Now;
        public SKBN? Skbn { get; set; }
        public ICollection<ItemPersyaratan> ItemPersyaratan { get; set; } = new List<ItemPersyaratan>();
        public string? Catatan { get; set; }
        public string? Nomor => $"P-SKBN{Id.ToString("D5")}"; 
    }
}
