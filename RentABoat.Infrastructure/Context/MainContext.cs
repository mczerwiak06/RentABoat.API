﻿using Microsoft.EntityFrameworkCore;
using RentABoat.Infrastructure.Entities;

namespace RentABoat.Infrastructure.Context;

public class MainContext : DbContext
{

    
    public MainContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Boat> Boat { get; set; }
    public DbSet<SailorAccount> SailorAccount { get; set; }

    public MainContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.RentABoat.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Boat>()
            .HasOne(x => x.SailorAccount)
            .WithMany(x =>x.Id)
            /*.WithOne(x => x.Boat)#1#
            .OnDelete(DeleteBehavior.Cascade);*/
        modelBuilder.Entity<SailorAccount>()
            .HasOne(x => x.Boat)
            .WithOne(x => x.SailorAccount)
            .HasForeignKey<Boat>(x=>x.SailorAccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}