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
builder.Services.AddScoped<IAssetManagementQuery, AssetManagementQueryRepo>();
builder.Services.AddScoped<IBankDepositsQuery, BankDepositsQueryRepo>();
builder.Services.AddScoped<IBankReconciliationQuery, BankReconciliationQueryRepo>();
builder.Services.AddScoped<IBanksQuery, BanksQueryRepo>();
builder.Services.AddScoped<IBudgetingQuery, BudgetingQueryRepo>();
builder.Services.AddScoped<ICapitationsQuery, CapitationsQueryRepo>();
builder.Services.AddScoped<ICashierShiftsQuery, CashierShiftsQueryRepo>();
builder.Services.AddScoped<ICashTransfersQuery, CashTransfersQueryRepo>();
builder.Services.AddScoped<IChequesQuery, ChequesQueryRepo>();
builder.Services.AddScoped<ICurrencyUnitsQuery, CurrencyUnitsQueryRepo>();
builder.Services.AddScoped<IFiscalPeriodsQuery, FiscalPeriodsQueryRepo>();
builder.Services.AddScoped<IGeneralLedgerAccountsQuery, GeneralLedgerAccountsQueryRepo>();
builder.Services.AddScoped<IJournalVouchersQuery, JournalVouchersQueryRepo>();
builder.Services.AddScoped<IOpeningBalancesQuery, OpeningBalancesQueryRepo>();
builder.Services.AddScoped<IPaymentModesQuery, PaymentModesQueryRepo>();
builder.Services.AddScoped<ISchemeItemsQuery, SchemeItemsQueryRepo>();
builder.Services.AddScoped<ISchemesQuery, SchemesQueryRepo>();
builder.Services.AddScoped<IPaymentModesQuery, PaymentModesQueryRepo>();
builder.Services.AddScoped<ITaxesQuery, TaxesQueryRepo>();
//Command
builder.Services.AddScoped<IAssetManagementCommand, AssetManagementCommandRepo>();
builder.Services.AddScoped<IBankDepositsCommand, BankDepositsCommandRepo>();
builder.Services.AddScoped<IBankReconciliationCommand, BankReconciliationCommandRepo>();
builder.Services.AddScoped<IBanksCommand, BanksCommandRepo>();
builder.Services.AddScoped<IBudgetingCommand, BudgetingCommandRepo>();
builder.Services.AddScoped<ICapitationsCommand, CapitationsCommandRepo>();
builder.Services.AddScoped<ICashierShiftsCommand, CashierShiftsCommandRepo>();
builder.Services.AddScoped<ICashTransfersCommand, CashTransfersCommandRepo>();
builder.Services.AddScoped<IChequesCommand, ChequesCommandRepo>();
builder.Services.AddScoped<ICurrencyUnitsCommand, CurrencyUnitsCommandRepo>();
builder.Services.AddScoped<IFiscalPeriodsCommand, FiscalPeriodsCommandRepo>();
builder.Services.AddScoped<IGeneralLedgerAccountsCommand, GeneralLedgerAccountsCommandRepo>();
builder.Services.AddScoped<IJournalVouchersCommand, JournalVouchersCommandRepo>();
builder.Services.AddScoped<IOpeningBalancesCommand, OpeningBalancesCommandRepo>();
builder.Services.AddScoped<IPaymentModesCommand, PaymentModesCommandRepo>();
builder.Services.AddScoped<ISchemeItemsCommand, SchemeItemsCommandRepo>();
builder.Services.AddScoped<ISchemesCommand, SchemesCommandRepo>();
builder.Services.AddScoped<IPaymentModesCommand, PaymentModesCommandRepo>();
builder.Services.AddScoped<ITaxesCommand, TaxesCommandRepo>();

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
