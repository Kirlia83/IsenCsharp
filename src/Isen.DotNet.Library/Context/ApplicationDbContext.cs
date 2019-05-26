using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Isen.DotNet.Library.Models;
//using System.Data.Entity;

namespace Isen.DotNet.Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> CityCollection {get; set;}
        public DbSet<Person> PersonCollection {get; set;}
        public DbSet<Player> PlayerCollection {get; set;}
        public DbSet<Club> ClubCollection {get; set;}
        public DbSet<Contract> ContractCollection {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Préciser les tables et les relations du modèle
            modelBuilder.Entity<City>()
                .ToTable(nameof(City));
            modelBuilder.Entity<Person>()
                .ToTable(nameof(Person))
                .HasOne(p => p.BornIn)
                .WithMany(c => c.PersonCollection)
                .HasForeignKey(p => p.BornInId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Player>()
                .ToTable(nameof(Player));
            modelBuilder.Entity<Club>()
                .ToTable(nameof(Club));
            modelBuilder.Entity<Contract>()
                .ToTable(nameof(Contract))
                .HasOne(c => c.PlayerContract)
                .WithMany(p => p.Historic)
                .HasForeignKey(c => c.PlayerId)
                .HasConstraintName("ForeignKey_Contract_Player");
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ClubContract)
                .WithMany(cl => cl.ContractCollection)
                .HasForeignKey(c => c.ClubId)
                .HasConstraintName("ForeignKey_Contract_Club");
           
            
            
        }
    }
}