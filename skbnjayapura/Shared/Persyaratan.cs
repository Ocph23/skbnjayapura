using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public class Persyaratan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public bool IsPhoto { get; set; }
        public bool Aktif { get; set; }

    }
}
