using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class SäiliöInfo
{
    [Key]
    public int SäiliöId { get; set; } // Tämä toimii FK ja PK yhtenäisyyden vuoksi
    public string InfoTxt { get; set; } = "";

    public virtual Säiliö Säiliö { get; set; } = null!;
}