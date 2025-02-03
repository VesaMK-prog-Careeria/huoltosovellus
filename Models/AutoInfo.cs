using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class AutoInfo
{
    [Key]
    public int AutoId { get; set; } // Tämä toimii FK ja PK yhtenäisyyden vuoksi
    public string InfoTxt { get; set; }

    public virtual Auto Auto { get; set; }
}