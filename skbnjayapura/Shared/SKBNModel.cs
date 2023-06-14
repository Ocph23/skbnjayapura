using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public record SKBNModel( int Id, string Nomor, Profile Profile, string NomorSKPN, DateTime TanggalSKPN, 
        string Keperluan, DateTime Mulai, DateTime Selesai, DateTime TanggalPenetapan, DateTime? TanggalPengambilan, string DiambilOleh);
}
