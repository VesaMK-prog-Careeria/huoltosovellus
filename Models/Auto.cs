namespace AutoHuoltoSovellus.Models;

public class Auto
{
    public int AutoId { get; set; }
    public string Rekisterinumero { get; set; } = "";
    public int? SäiliöId { get; set; }
    public DateTime KatsastusPvm { get; set; }
    public DateTime ADRPvm { get; set; }
    public DateTime PiirturiPvm { get; set; }
    public DateTime AlkolukkoPvm { get; set; }
    public DateTime NopeudenrajoitinPvm { get; set; }
    public int AutoInfoId { get; set; }

    public virtual Säiliö? Säiliö { get; set; }
    public virtual AutoInfo? AutoInfo { get; set; }
    public virtual ICollection<AutoHuollot>? Huollot { get; set; }
}