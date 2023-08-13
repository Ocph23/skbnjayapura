namespace skbnjayapura.Shared
{
    public class SKBN
    {
        public int Id { get; set; }
        public string? Nomor { get; set; } = string.Empty;
        public string? NomorSKPN { get; set; }
        public DateTime? TanggalSKPN { get; set; }
        public DateTime? BerlakuMulai { get; set; } = DateTime.Now;
        public DateTime? BerlakuSelesai { get; set; }
        public DateTime? TanggalPersetujuan { get; set; } =DateTime.Now;
        public DateTime? TangglPengambilan { get; set; }
        public string? DiambilOleh { get; set; } = string.Empty;
        public string NomorView => TanggalPersetujuan == null ? "" : $"SKBN/{Nomor}/{GetBulan(TanggalPersetujuan.Value)}/{TanggalPersetujuan.Value.Year}/Narkoba";
        public Pimpinan? DiSetujuiOleh { get; set; }

        string GetBulan(DateTime date) => date.Month switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            10 => "X",
            11 => "XI",
            12 => "XII",
            _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
        };
    }
}