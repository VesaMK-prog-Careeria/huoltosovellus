namespace AutoHuoltoSovellus.Models;

public class Auto
{
    public int AutoId { get; set; }
    public string Rekisterinumero { get; set; }
    public int? SäiliöId { get; set; }
    public DateTime KatsastusPvm { get; set; }
    public DateTime ADR { get; set; }
    public DateTime Piirturi { get; set; }
    public DateTime Alkolukko { get; set; }
    public DateTime Nopeudenrajoitin { get; set; }
    public int AutoInfoId { get; set; }

    public virtual Säiliö? Säiliö { get; set; }
    public virtual AutoInfo? AutoInfo { get; set; }
    public virtual ICollection<AutoHuollot>? Huollot { get; set; }
}