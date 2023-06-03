using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skbnjayapura.Shared
{
    public static class Helper
    {
        public static string[] GetGender()
        {
            return new string[] { "Laki-Laki", "Perempuan" };
        }

        public static string[] GetKebangsaan()
        {
            return new string[] { "Warga Negara Indonesia", "Warga Negara Asing" };
        }

        public static string[] GetAgama()
        {
            return new string[] { "Islam", "Kristen", "Katolik","Hindu", "Budha", "Kong Hu Chu", "Kepercayaan kepada Tuhan Yang Maha Esa" };
        }

    }
}
