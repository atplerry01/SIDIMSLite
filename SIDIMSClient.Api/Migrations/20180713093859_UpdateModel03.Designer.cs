﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIDIMSClient.Api.Persistence;

namespace SIDIMSClient.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180713093859_UpdateModel03")]
    partial class UpdateModel03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Account.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Account.Audience", b =>
                {
                    b.Property<string>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32);

                    b.Property<string>("Base64Secret")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ClientId");

                    b.ToTable("Audience");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Account.Client", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("AllowedOrigin")
                        .HasMaxLength(100);

                    b.Property<int>("ApplicationType");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("RefreshTokenLifeTime");

                    b.Property<string>("Secret")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Account.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiresUtc");

                    b.Property<DateTime>("IssuedUtc");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Token")
                        .HasName("refreshToken_Token");


                    b.HasAlternateKey("UserId")
                        .HasName("refreshToken_UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardIssuance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientStockReportId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ClientStockReportId");

                    b.HasIndex("ProductId");

                    b.ToTable("CardIssuance");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardIssuanceLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardIssuanceId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("QuantityIssued");

                    b.HasKey("Id");

                    b.HasIndex("CardIssuanceId");

                    b.ToTable("CardIssuanceLog");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientVaultReportId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Remark");

                    b.Property<int>("SidProductId");

                    b.HasKey("Id");

                    b.HasIndex("ClientVaultReportId");

                    b.HasIndex("SidProductId");

                    b.ToTable("CardReceipt");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientStockLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardIssuanceId");

                    b.Property<int?>("ClientStockReportId");

                    b.Property<int>("ClosingStock");

                    b.Property<int>("IssuanceQty");

                    b.Property<int>("OpeningStock");

                    b.HasKey("Id");

                    b.HasIndex("CardIssuanceId");

                    b.HasIndex("ClientStockReportId");

                    b.ToTable("ClientStockLog");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientStockReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientVaultReportId");

                    b.Property<int>("ClosingStock");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CurrentStock");

                    b.Property<string>("FileName");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("OpeningStock");

                    b.Property<int?>("QtyIssued");

                    b.Property<int>("SidProductId");

                    b.HasKey("Id");

                    b.HasIndex("ClientVaultReportId");

                    b.HasIndex("SidProductId");

                    b.ToTable("ClientStockReport");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientVaultReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosingStock");

                    b.Property<DateTime>("CreateOn");

                    b.Property<int>("CurrentStock");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("OpeningStock");

                    b.Property<int>("SidProductId");

                    b.HasKey("Id");

                    b.HasIndex("SidProductId");

                    b.ToTable("ClientVaultReport");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.WasteIssuance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("InventoryId");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<int>("WasteQuantity");

                    b.HasKey("Id");

                    b.ToTable("WasteIssuance");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Lookups.SidClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("ShortCode");

                    b.HasKey("Id");

                    b.ToTable("SidClient");

                    b.HasData(
                        new { Id = 1, Name = "First Bank", ShortCode = "FBN" }
                    );
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Lookups.SidProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("ShortCode");

                    b.Property<int>("SidClientId");

                    b.HasKey("Id");

                    b.HasIndex("SidClientId");

                    b.ToTable("SidProduct");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Lookups.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Account.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Account.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIDIMSClient.Api.Models.Account.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Account.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Account.RefreshToken", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Account.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardIssuance", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Inventory.ClientStockReport", "ClientStockReport")
                        .WithMany()
                        .HasForeignKey("ClientStockReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIDIMSClient.Api.Models.Lookups.SidProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardIssuanceLog", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Inventory.CardIssuance", "CardIssuance")
                        .WithMany()
                        .HasForeignKey("CardIssuanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.CardReceipt", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Inventory.ClientVaultReport", "ClientVaultReport")
                        .WithMany()
                        .HasForeignKey("ClientVaultReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIDIMSClient.Api.Models.Lookups.SidProduct", "SidProduct")
                        .WithMany()
                        .HasForeignKey("SidProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientStockLog", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Inventory.CardIssuance", "CardIssuance")
                        .WithMany()
                        .HasForeignKey("CardIssuanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIDIMSClient.Api.Models.Inventory.ClientStockReport", "ClientStockReport")
                        .WithMany("StockLogs")
                        .HasForeignKey("ClientStockReportId");
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientStockReport", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Inventory.ClientVaultReport", "ClientVaultReport")
                        .WithMany()
                        .HasForeignKey("ClientVaultReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIDIMSClient.Api.Models.Lookups.SidProduct", "SidProduct")
                        .WithMany()
                        .HasForeignKey("SidProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Inventory.ClientVaultReport", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Lookups.SidProduct", "SidProduct")
                        .WithMany()
                        .HasForeignKey("SidProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIDIMSClient.Api.Models.Lookups.SidProduct", b =>
                {
                    b.HasOne("SIDIMSClient.Api.Models.Lookups.SidClient", "SidClient")
                        .WithMany()
                        .HasForeignKey("SidClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
