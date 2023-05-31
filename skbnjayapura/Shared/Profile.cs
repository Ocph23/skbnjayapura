using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public class Profile
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public string JenisKelamin { get; set; } = "Laki-Laki";
        public string? Kebangsaan { get; set; }
        public string? Agama { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string? Pekerjaan { get; set; }
        public string? Alamat { get; set; }
        public string? NomorHP { get; set; }
        public string? Photo { get; set; }
        public string? UserId { get; set; }
    }
}
