using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class SäiliöHuollot
{
    [Key]
    public int HuollonId { get; set; }
    public int SäiliöId { get; set; }
    public DateTime HuoltoPvm { get; set; }
    public string HuoltoPaikka { get; set; }
    public string HuollonKuvaus { get; set; }
    public byte[] HuollonTyyppi { get; set; }

    public virtual Säiliö Säiliö { get; set; }
}