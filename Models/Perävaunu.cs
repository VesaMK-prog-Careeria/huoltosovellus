namespace AutoHuoltoSovellus.Models;

public class Perävaunu
{
    public int PerävaunuId { get; set; }
    public string Rekisterinumero { get; set; }
    public DateTime KatsastusPvm { get; set; }
    public DateTime ADR { get; set; }
    public DateTime Välitarkastus { get; set; }
    public DateTime Määräaikaistarkastus { get; set; }
    public int PerävaunuInfoId { get; set; }

    public virtual PerävaunuInfo? PerävaunuInfo { get; set; }
    public virtual ICollection<PerävaunuHuollot>? Huollot { get; set; }
}