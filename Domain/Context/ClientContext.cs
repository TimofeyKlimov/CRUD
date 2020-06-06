using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Domain.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext() 
        {
            Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Constitutor> Constitutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Clients;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients").HasKey(s => s.Id);
            modelBuilder.Entity<Client>().Property(s => s.TIN).HasMaxLength(16).IsRequired();
            modelBuilder.Entity<Client>().Property(s => s.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Constitutor>().ToTable("Constitutors").HasKey(s => s.Id);
            modelBuilder.Entity<Constitutor>().Property(s => s.FullName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Constitutor>().Property(s => s.TIN).HasMaxLength(16).IsRequired();

            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    Id = Guid.NewGuid(),
                    Name = "TestName",
                    TIN = 258778601124,
                    ClientType = ClientType.IndividualEntrepreneur,
                    CreateDate = DateTime.Now
                });

        }
    }
}
