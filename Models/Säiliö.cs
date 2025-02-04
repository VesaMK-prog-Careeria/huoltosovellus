namespace AutoHuoltoSovellus.Models;

public class Säiliö
{
    public int SäiliöId { get; set; }
    public int SäiliöNro { get; set; }
    public DateTime VakausPvm { get; set; }
    public DateTime VälitarkastusPvm { get; set; }
    public DateTime MääräaikaistarkastusPvm { get; set; }
    public int SäiliöInfoId { get; set; }

    public virtual SäiliöInfo? SäiliöInfo { get; set; }
    public virtual ICollection<SäiliöHuollot>? Huollot { get; set; }
}