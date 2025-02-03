using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class PerävaunuHuollot
{
    [Key]
    public int HuollonId { get; set; }
    public int PerävaunuId { get; set; }
    public DateTime HuoltoPvm { get; set; }
    public string HuoltoPaikka { get; set; } = "";
    public string HuollonKuvaus { get; set; } = "";
    public byte[] HuollonTyyppi { get; set; } = new byte[0];

    public virtual Perävaunu Perävaunu { get; set; } = null!;
}