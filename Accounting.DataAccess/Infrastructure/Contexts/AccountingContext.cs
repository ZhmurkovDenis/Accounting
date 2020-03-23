using Accounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.DataAccess.Infrastructure.Contexts
{
    public class AccountingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public AccountingContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AccountingDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, Name = "Denis"},
                    new User { Id = 2, Name = "Konstantin"}
                });

            modelBuilder.Entity<Currency>().HasData(
                new Currency[]
                {
                    new Currency() { Id = 1, Code = "RUB"},
                    new Currency() { Id = 2, Code = "USD"},
                    new Currency() { Id = 3, Code = "EUR"},
                });

            modelBuilder.Entity<Account>().HasData(
                new Account[]
                {
                    new Account() { Id = 1, CurrencyId = 1, UserId = 1, Balance = 0 },
                    new Account() { Id = 2, CurrencyId = 2, UserId = 1, Balance = 0},
                    new Account() { Id = 3, CurrencyId = 3, UserId = 1, Balance = 0},
                    new Account() { Id = 4, CurrencyId = 1, UserId = 2, Balance = 0 },
                    new Account() { Id = 5, CurrencyId = 2, UserId = 2, Balance = 0},
                    new Account() { Id = 6, CurrencyId = 3, UserId = 2, Balance = 0},
                });

            modelBuilder.Entity<Account>()
                .HasOne(acc => acc.User)
                .WithMany(u => u.Accounts).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
