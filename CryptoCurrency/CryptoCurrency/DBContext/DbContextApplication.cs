using CryptoCurrency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace CryptoCurrency.DBContext
{
    public class DbContextApplication : DbContext
    {
        public IConfiguration _config {  get; set; }
        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
        public DbSet<DeletedCryptocurrency> DeletedCryptocurrencies { get; set; }
        public DbContextApplication(IConfiguration config)
        {
            _config = config;
            Database.Migrate();
        }
        public DbContextApplication() { }

        //configuration method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }


        //in this method i have written one-to-one relationship between DeletedCryptocurrency and Cryptocurrency
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeletedCryptocurrency>()
                .HasOne(el => el.Crypto)
                .WithOne()
                .HasForeignKey<DeletedCryptocurrency>(el => el.IdCrypto)
                .IsRequired();
        }
    }
}
