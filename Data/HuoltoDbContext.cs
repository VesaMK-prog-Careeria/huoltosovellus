namespace AutoHuoltoSovellus.Data;

using Microsoft.EntityFrameworkCore;
using AutoHuoltoSovellus.Models;

public class HuoltoDbContext : DbContext
{
    public HuoltoDbContext(DbContextOptions<HuoltoDbContext> options) : base(options) {}

    public DbSet<Auto> Autot { get; set; }
    public DbSet<Perävaunu> Perävaunut { get; set; }
    public DbSet<Säiliö> Säiliöt { get; set; }
    public DbSet<AutoHuollot> AutoHuollot { get; set; }
    public DbSet<PerävaunuHuollot> PerävaunuHuollot { get; set; }
    public DbSet<SäiliöHuollot> SäiliöHuollot { get; set; }
    public DbSet<AutoInfo> AutoInfot { get; set; }
    public DbSet<PerävaunuInfo> PerävaunuInfot { get; set; }
    public DbSet<SäiliöInfo> SäiliöInfot { get; set; }
    public DbSet<Huoltopaikat> Huoltopaikat { get; set; }
    public DbSet<Kuva> Kuvat { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);

    // Auto ↔ AutoInfo (One-to-One)
    modelBuilder.Entity<Auto>()
        .HasOne(a => a.AutoInfo)
        .WithOne(ai => ai.Auto)
        .HasForeignKey<AutoInfo>(ai => ai.AutoId);

    // Perävaunu ↔ PerävaunuInfo (One-to-One)
    modelBuilder.Entity<Perävaunu>()
        .HasOne(p => p.PerävaunuInfo)
        .WithOne(pi => pi.Perävaunu)
        .HasForeignKey<PerävaunuInfo>(pi => pi.PerävaunuId);

    // Säiliö ↔ SäiliöInfo (One-to-One)
    modelBuilder.Entity<Säiliö>()
        .HasOne(s => s.SäiliöInfo)
        .WithOne(si => si.Säiliö)
        .HasForeignKey<SäiliöInfo>(si => si.SäiliöId);
    }

}