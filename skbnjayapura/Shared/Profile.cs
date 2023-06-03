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
        public string? JenisKelamin { get; set; }
        public string? Kebangsaan { get; set; }
        public string? Agama { get; set; }
        public string? TempatLahir { get; set; }
        public DateTime TanggalLahir { get; set; } = DateTime.Now.AddYears(-17);
        public string? Pekerjaan { get; set; }
        public string? Alamat { get; set; } = string.Empty;
        public string? NomorNIK { get; set; } =string.Empty;
        public string? NomorHP { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public bool Aktif { get; set; } = true;
        public string? UserId { get; set; }
    }
}
