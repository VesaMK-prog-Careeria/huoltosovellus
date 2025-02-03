using System.ComponentModel.DataAnnotations;

namespace AutoHuoltoSovellus.Models;

public class Huoltopaikat
{
    [Key]
    public int HuoltopaikkaId { get; set; }
    public string Huoltopaikka { get; set; } = "";

    public virtual ICollection<AutoHuollot>? AutoHuollot { get; set; }
    public virtual ICollection<PerävaunuHuollot>? PerävaunuHuollot { get; set; }
    public virtual ICollection<SäiliöHuollot>? SäiliöHuollot { get; set; }
}