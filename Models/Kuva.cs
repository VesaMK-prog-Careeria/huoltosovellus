using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class Kuva
{
    [Key]
    public int KuvaId { get; set; }
    public int AutoInfoId { get; set; }
    public int SäiliöInfoId { get; set; }
    public int PerävaunuInfoId { get; set; }
    public string KuvaNimi { get; set; }
    public byte[] KuvaData { get; set; }
    public string KuvaTyyppi { get; set; }
    public int EntityId { get; set; }

}