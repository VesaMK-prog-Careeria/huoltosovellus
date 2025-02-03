using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class PerävaunuInfo
{
    [Key]
    public int PerävaunuId { get; set; } // Tämä toimii sekä FK että PK yhtenäisyyden vuoksi
    public string InfoTxt { get; set; }

    public virtual Perävaunu Perävaunu { get; set; }
}