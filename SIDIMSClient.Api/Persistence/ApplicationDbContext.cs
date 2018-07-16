using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIDIMSClient.Api.Models;
using SIDIMSClient.Api.Models.Account;
using SIDIMSClient.Api.Models.Inventory;
using SIDIMSClient.Api.Models.Lookups;
using SIDIMSClient.Api.Persistence.Configuration;

namespace SIDIMSClient.Api.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            
            modelBuilder.Entity<SidClient>().HasData(new SidClient { Id = 1, Name = "First Bank", ShortCode = "FBN"});

            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.UserId)
                .HasName("refreshToken_UserId");
            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.Token)
                .HasName("refreshToken_Token");

            base.OnModelCreating(modelBuilder);
        }

        ///Account Sections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        ///Lookups
        public DbSet<SidClient> SidClients { get; set; }
        public DbSet<SidProduct> SidProducts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }


        //Inventory
        public DbSet<CardReceipt> CardReceipts { get; set; }
        public DbSet<ClientStockLog> ClientStockLogs { get; set; }
        public DbSet<ClientStockReport> ClientStockReports { get; set; }
        public DbSet<ClientVaultReport> ClientVaultReports { get; set; }
        public DbSet<CardIssuance> CardIssuances { get; set; }
        public DbSet<CardIssuanceLog> CardIssuanceLogs { get; set; }
        public DbSet<WasteIssuance> WasteIssuances { get; set; }

        public void InsertNew(RefreshToken token)
        {
            var tokenModel = RefreshTokens.SingleOrDefault(i => i.UserId == token.UserId);
            if (tokenModel != null)
            {
                RefreshTokens.Remove(tokenModel);
                SaveChanges();
            }
            RefreshTokens.Add(token);
            SaveChanges();
        }

    }

}