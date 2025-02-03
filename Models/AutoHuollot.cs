using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class AutoHuollot
{
    [Key]
    public int HuollonId { get; set; }
    public int AutoId { get; set; }
    public DateTime HuoltoPvm { get; set; }
    public string HuoltoPaikka { get; set; } = "";
    public string HuollonKuvaus { get; set; } = "";
    public byte[] HuollonTyyppi { get; set; } = new byte[0];

    public virtual Auto Auto { get; set; } = null!;
}