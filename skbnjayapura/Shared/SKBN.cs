namespace skbnjayapura.Shared
{
    public class SKBN
    {
        public int Id { get; set; }

        public string? Nomor { get; set; }
        public string? NomorSKPN { get; set; }
        public DateTime? TanggalSKPN { get; set; }
        public DateTime? BerlakuMulai { get; set; } = DateTime.Now;
        public DateTime? BerlakuSelesai { get; set; }
        public DateTime? TanggalPersetujuan { get; set; } = DateTime.Now;
    }
}