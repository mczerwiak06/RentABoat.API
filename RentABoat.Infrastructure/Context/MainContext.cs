using Microsoft.EntityFrameworkCore;
using RentABoat.Infrastructure.Entities;

namespace RentABoat.Infrastructure.Context;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    public MainContext()
    {
    }

    public DbSet<Boat> Boat { get; set; }
    public DbSet<SailorAccount> SailorAccount { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.RentABoat.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SailorAccount>()
            .HasOne(x => x.Boat)
            .WithOne(x => x.SailorAccount)
            .HasForeignKey<Boat>(x => x.SailorAccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}