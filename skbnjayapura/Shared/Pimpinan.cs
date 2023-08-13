namespace skbnjayapura.Shared;

public class Pimpinan
{
    public int Id { get; set; }

    public  string? Name { get; set; }=string.Empty;
    public  string? Email { get; set; }=string.Empty;
    public  string? Jabatan { get; set; }=string.Empty;

    public  string? Pangkat { get; set; }=string.Empty;

    public  string? NRP { get; set; }=string.Empty;

    public bool Active { get; set; } = true;

    public string? UserId { get; set; }

}
