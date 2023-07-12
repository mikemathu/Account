﻿// <auto-generated />
using System;
using Accounts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Accounts.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Accounts.Models.AccountClass", b =>
                {
                    b.Property<int>("AccountClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountClassID"));

                    b.Property<int>("AccountType")
                        .HasColumnType("integer");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountClassID");

                    b.ToTable("GeneralLedger_AccountClasses");
                });

            modelBuilder.Entity("Accounts.Models.AccountDetail", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountID"));

                    b.Property<int>("AccountClassID")
                        .HasColumnType("integer");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AccountNo")
                        .HasColumnType("integer");

                    b.Property<int>("CashFlowCategoryID")
                        .HasColumnType("integer");

                    b.Property<int>("ConfigurationType")
                        .HasColumnType("integer");

                    b.Property<int>("IsLocked")
                        .HasColumnType("integer");

                    b.HasKey("AccountID");

                    b.HasIndex("AccountClassID");

                    b.HasIndex("CashFlowCategoryID");

                    b.HasIndex("ConfigurationType");

                    b.ToTable("GeneralLedger_AccountsDetails");
                });

            modelBuilder.Entity("Accounts.Models.AccountType", b =>
                {
                    b.Property<int>("AccountTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountTypeID"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountTypeID");

                    b.ToTable("GeneralLedger_AccountTypes");
                });

            modelBuilder.Entity("Accounts.Models.Banks.Bank", b =>
                {
                    b.Property<int>("BankID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BankID"));

                    b.Property<int>("AccountNo")
                        .HasColumnType("integer");

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BranchCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyBranchID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubAccountID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BankID");

                    b.ToTable("Banks_Banks");
                });

            modelBuilder.Entity("Accounts.Models.CashFlowCategory", b =>
                {
                    b.Property<int>("CashFlowCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CashFlowCategoryID"));

                    b.Property<int>("AccountTypeID")
                        .HasColumnType("integer");

                    b.Property<int>("IsActive")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CashFlowCategoryID");

                    b.HasIndex("AccountTypeID");

                    b.ToTable("GeneralLedger_CashFlowCategories");
                });

            modelBuilder.Entity("Accounts.Models.Configuration", b =>
                {
                    b.Property<int>("ConfigurationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConfigurationType"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ConfigurationType");

                    b.ToTable("GeneralLedger_Configurations");
                });

            modelBuilder.Entity("Accounts.Models.FiscalPeriod", b =>
                {
                    b.Property<int>("FiscalPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FiscalPeriodId"));

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IsActive")
                        .HasColumnType("integer");

                    b.Property<int>("IsOpen")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FiscalPeriodId");

                    b.ToTable("GeneralLedger_FiscalPeriods");
                });

            modelBuilder.Entity("Accounts.Models.JournalVoucher", b =>
                {
                    b.Property<int>("JournalVoucherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JournalVoucherId"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FiscalNo")
                        .HasColumnType("integer");

                    b.Property<string>("PostedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceReference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TrasnactionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("JournalVoucherId");

                    b.ToTable("GeneralLedger_JournalVouchers");
                });

            modelBuilder.Entity("Accounts.Models.LetterCase", b =>
                {
                    b.Property<int>("LetterCaseType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LetterCaseType"));

                    b.HasKey("LetterCaseType");

                    b.ToTable("GeneralLedger_LetterCases");
                });

            modelBuilder.Entity("Accounts.Models.Payment_Modes.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentID"));

                    b.HasKey("PaymentID");

                    b.ToTable("PaymentModes_Payments");
                });

            modelBuilder.Entity("Accounts.Models.Payment_Modes.PaymentMode", b =>
                {
                    b.Property<string>("PaymentModeID")
                        .HasColumnType("text");

                    b.Property<string>("CanBeReceived")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IsDefault")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaymentID")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentModeCategotyID")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentModeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaymentModeSelectionLevelID")
                        .HasColumnType("integer");

                    b.Property<string>("SubAcc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubAccountID")
                        .HasColumnType("integer");

                    b.HasKey("PaymentModeID");

                    b.ToTable("PaymentModes_PaymentModes");
                });

            modelBuilder.Entity("Accounts.Models.Payment_Modes.PaymentModeCategory", b =>
                {
                    b.Property<int>("PaymentModeCategotyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentModeCategotyID"));

                    b.Property<string>("PaymentModeCategotyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentModeCategotyID");

                    b.ToTable("PaymentModes_PaymentModeCategories");
                });

            modelBuilder.Entity("Accounts.Models.Payment_Modes.PaymentModeSelectionLevel", b =>
                {
                    b.Property<int>("PaymentModeSelectionLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentModeSelectionLevelID"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("PaymentModeSelectionLevelID");

                    b.ToTable("PaymentModes_PaymentModeSelectionLevels");
                });

            modelBuilder.Entity("Accounts.Models.Payment_Modes.SubAccount", b =>
                {
                    b.Property<int>("SubAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubAccountID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("integer");

                    b.Property<int>("ConfigyrationType")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("integer");

                    b.Property<int>("IsActive")
                        .HasColumnType("integer");

                    b.Property<int>("IsLocked")
                        .HasColumnType("integer");

                    b.Property<string>("SubAccountName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubAccountID");

                    b.ToTable("PaymentModes_SubAccounts");
                });

            modelBuilder.Entity("Accounts.Models.SubAccountDetail", b =>
                {
                    b.Property<int>("SubAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubAccountID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("integer");

                    b.Property<int>("ConfigurationType")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("integer");

                    b.Property<int>("IsActive")
                        .HasColumnType("integer");

                    b.Property<int>("IsLocked")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubAccountID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ConfigurationType");

                    b.ToTable("GeneralLedger_SubAccountsDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Accounts.Models.AccountDetail", b =>
                {
                    b.HasOne("Accounts.Models.AccountClass", "AccountClass")
                        .WithMany()
                        .HasForeignKey("AccountClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Models.CashFlowCategory", "CashFlowCategory")
                        .WithMany()
                        .HasForeignKey("CashFlowCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Models.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountClass");

                    b.Navigation("CashFlowCategory");

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Accounts.Models.CashFlowCategory", b =>
                {
                    b.HasOne("Accounts.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("Accounts.Models.SubAccountDetail", b =>
                {
                    b.HasOne("Accounts.Models.AccountDetail", "AccountDetail")
                        .WithMany("SubAccounts")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounts.Models.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountDetail");

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Accounts.Models.AccountDetail", b =>
                {
                    b.Navigation("SubAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
