namespace AutoHuoltoSovellus.Models;

public class Säiliö
{
    public int SäiliöId { get; set; }
    public int SäiliöNro { get; set; }
    public DateTime Vakaus { get; set; }
    public DateTime Välitarkastus { get; set; }
    public DateTime Määräaikaistarkastus { get; set; }
    public int SäiliöInfoId { get; set; }

    public virtual SäiliöInfo? SäiliöInfo { get; set; }
    public virtual ICollection<SäiliöHuollot>? Huollot { get; set; }
}