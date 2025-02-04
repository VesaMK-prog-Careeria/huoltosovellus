namespace AutoHuoltoSovellus.Models;

public class Perävaunu
{
    public int PerävaunuId { get; set; }
    public string Rekisterinumero { get; set; } = "";
    public DateTime KatsastusPvm { get; set; }
    public DateTime ADRPvm { get; set; }
    public DateTime VälitarkastusPvm { get; set; }
    public DateTime MääräaikaistarkastusPvm { get; set; }
    public int PerävaunuInfoId { get; set; }

    public virtual PerävaunuInfo? PerävaunuInfo { get; set; }
    public virtual ICollection<PerävaunuHuollot>? Huollot { get; set; }
}