using Accounts.Repositories.Command;
using Accounts.Repositories.Query;
using Accounts.Services.Command;
using Accounts.Services.Query;
using Accounts.Data;
using Accounts.Repositories.CommandRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

//Query
builder.Services.AddSingleton<IAssetManagementQuery, AssetManagementQueryRepo>();
builder.Services.AddSingleton<IBankDepositsQuery, BankDepositsQueryRepo>();
builder.Services.AddSingleton<IBankReconciliationQuery, BankReconciliationQueryRepo>();
builder.Services.AddSingleton<IBanksQuery, BanksQueryRepo>();
builder.Services.AddSingleton<IBudgetingQuery, BudgetingQueryRepo>();
builder.Services.AddSingleton<ICapitationsQuery, CapitationsQueryRepo>();
builder.Services.AddSingleton<ICashierShiftsQuery, CashierShiftsQueryRepo>();
builder.Services.AddSingleton<ICashTransfersQuery, CashTransfersQueryRepo>();
builder.Services.AddSingleton<IChequesQuery, ChequesQueryRepo>();
builder.Services.AddSingleton<ICurrencyUnitsQuery, CurrencyUnitsQueryRepo>();
builder.Services.AddSingleton<IFiscalPeriodsQuery, FiscalPeriodsQueryRepo>();
builder.Services.AddSingleton<IGeneralLedgerAccountsQuery, GeneralLedgerAccountsQueryRepo>();
builder.Services.AddSingleton<IJournalVouchersQuery, JournalVouchersQueryRepo>();
builder.Services.AddSingleton<IOpeningBalancesQuery, OpeningBalancesQueryRepo>();
builder.Services.AddSingleton<IPaymentModesQuery, PaymentModesQueryRepo>();
builder.Services.AddSingleton<ISchemeItemsQuery, SchemeItemsQueryRepo>();
builder.Services.AddSingleton<ISchemesQuery, SchemesQueryRepo>();
builder.Services.AddSingleton<IPaymentModesQuery, PaymentModesQueryRepo>();
builder.Services.AddSingleton<ITaxesQuery, TaxesQueryRepo>();
//Command
builder.Services.AddSingleton<IAssetManagementCommand, AssetManagementCommandRepo>();
builder.Services.AddSingleton<IBankDepositsCommand, BankDepositsCommandRepo>();
builder.Services.AddSingleton<IBankReconciliationCommand, BankReconciliationCommandRepo>();
builder.Services.AddSingleton<IBanksCommand, BanksCommandRepo>();
builder.Services.AddSingleton<IBudgetingCommand, BudgetingCommandRepo>();
builder.Services.AddSingleton<ICapitationsCommand, CapitationsCommandRepo>();
builder.Services.AddSingleton<ICashierShiftsCommand, CashierShiftsCommandRepo>();
builder.Services.AddSingleton<ICashTransfersCommand, CashTransfersCommandRepo>();
builder.Services.AddSingleton<IChequesCommand, ChequesCommandRepo>();
builder.Services.AddSingleton<ICurrencyUnitsCommand, CurrencyUnitsCommandRepo>();
builder.Services.AddSingleton<IFiscalPeriodsCommand, FiscalPeriodsCommandRepo>();
builder.Services.AddSingleton<IGeneralLedgerAccountsCommand, GeneralLedgerAccountsCommandRepo>();
builder.Services.AddSingleton<IJournalVouchersCommand, JournalVouchersCommandRepo>();
builder.Services.AddSingleton<IOpeningBalancesCommand, OpeningBalancesCommandRepo>();
builder.Services.AddSingleton<IPaymentModesCommand, PaymentModesCommandRepo>();
builder.Services.AddSingleton<ISchemeItemsCommand, SchemeItemsCommandRepo>();
builder.Services.AddSingleton<ISchemesCommand, SchemesCommandRepo>();
builder.Services.AddSingleton<IPaymentModesCommand, PaymentModesCommandRepo>();
builder.Services.AddSingleton<ITaxesCommand, TaxesCommandRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=GeneralLedgerAccounts}/{id?}");
app.MapRazorPages();

app.Run();
