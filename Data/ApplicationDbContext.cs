using Accounts.Models.Banks;
using Accounts.Models.Payment_Modes;
using Accounts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        static ApplicationDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<AccountClass> GeneralLedger_AccountClasses { get; set; }
        public DbSet<AccountDetail> GeneralLedger_AccountsDetails { get; set; }
        public DbSet<CashFlowCategory> GeneralLedger_CashFlowCategories { get; set; }
        public DbSet<Configuration> GeneralLedger_Configurations { get; set; }
        public DbSet<FiscalPeriod> GeneralLedger_FiscalPeriods { get; set; }
        public DbSet<JournalVoucher> GeneralLedger_JournalVouchers { get; set; }
        public DbSet<LetterCase> GeneralLedger_LetterCases { get; set; }
        public DbSet<SubAccountDetail> GeneralLedger_SubAccountsDetails { get; set; }
        public DbSet<AccountType> GeneralLedger_AccountTypes { get; set; }


        //Banks
        public DbSet<Bank> Banks_Banks { get; set; }
        //PaymentModes
        public DbSet<Payment> PaymentModes_Payments { get; set; }
        public DbSet<PaymentMode> PaymentModes_PaymentModes { get; set; }
        public DbSet<PaymentModeCategory> PaymentModes_PaymentModeCategories { get; set; }
        public DbSet<PaymentModeSelectionLevel> PaymentModes_PaymentModeSelectionLevels { get; set; }
        public DbSet<SubAccount> PaymentModes_SubAccounts { get; set; }
    }
}