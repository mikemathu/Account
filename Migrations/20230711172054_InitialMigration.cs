using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks_Banks",
                columns: table => new
                {
                    BankID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNo = table.Column<int>(type: "integer", nullable: false),
                    BankCode = table.Column<string>(type: "text", nullable: false),
                    Branch = table.Column<string>(type: "text", nullable: false),
                    BranchCode = table.Column<string>(type: "text", nullable: false),
                    CompanyBranchID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SubAccountID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks_Banks", x => x.BankID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_AccountClasses",
                columns: table => new
                {
                    AccountClassID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    ClassName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_AccountClasses", x => x.AccountClassID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_AccountTypes",
                columns: table => new
                {
                    AccountTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_AccountTypes", x => x.AccountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_Configurations",
                columns: table => new
                {
                    ConfigurationType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_Configurations", x => x.ConfigurationType);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_FiscalPeriods",
                columns: table => new
                {
                    FiscalPeriodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OpenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    IsOpen = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_FiscalPeriods", x => x.FiscalPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_JournalVouchers",
                columns: table => new
                {
                    JournalVoucherId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceReference = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TrasnactionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PostedBy = table.Column<string>(type: "text", nullable: false),
                    FiscalNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_JournalVouchers", x => x.JournalVoucherId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_LetterCases",
                columns: table => new
                {
                    LetterCaseType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_LetterCases", x => x.LetterCaseType);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes_PaymentModeCategories",
                columns: table => new
                {
                    PaymentModeCategotyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentModeCategotyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes_PaymentModeCategories", x => x.PaymentModeCategotyID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes_PaymentModes",
                columns: table => new
                {
                    PaymentModeID = table.Column<string>(type: "text", nullable: false),
                    CanBeReceived = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<string>(type: "text", nullable: false),
                    PaymentModeName = table.Column<string>(type: "text", nullable: false),
                    SubAcc = table.Column<string>(type: "text", nullable: false),
                    PaymentModeCategotyID = table.Column<int>(type: "integer", nullable: false),
                    PaymentID = table.Column<int>(type: "integer", nullable: false),
                    PaymentModeSelectionLevelID = table.Column<int>(type: "integer", nullable: false),
                    SubAccountID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes_PaymentModes", x => x.PaymentModeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes_PaymentModeSelectionLevels",
                columns: table => new
                {
                    PaymentModeSelectionLevelID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes_PaymentModeSelectionLevels", x => x.PaymentModeSelectionLevelID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes_Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes_SubAccounts",
                columns: table => new
                {
                    SubAccountID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountID = table.Column<int>(type: "integer", nullable: false),
                    ConfigyrationType = table.Column<int>(type: "integer", nullable: false),
                    CurrentBalance = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<int>(type: "integer", nullable: false),
                    SubAccountName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes_SubAccounts", x => x.SubAccountID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_CashFlowCategories",
                columns: table => new
                {
                    CashFlowCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AccountTypeID = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_CashFlowCategories", x => x.CashFlowCategoryID);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_CashFlowCategories_GeneralLedger_AccountTypes~",
                        column: x => x.AccountTypeID,
                        principalTable: "GeneralLedger_AccountTypes",
                        principalColumn: "AccountTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_AccountsDetails",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountClassID = table.Column<int>(type: "integer", nullable: false),
                    AccountNo = table.Column<int>(type: "integer", nullable: false),
                    CashFlowCategoryID = table.Column<int>(type: "integer", nullable: false),
                    ConfigurationType = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<int>(type: "integer", nullable: false),
                    AccountName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_AccountsDetails", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_AccountsDetails_GeneralLedger_AccountClasses_~",
                        column: x => x.AccountClassID,
                        principalTable: "GeneralLedger_AccountClasses",
                        principalColumn: "AccountClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_AccountsDetails_GeneralLedger_CashFlowCategor~",
                        column: x => x.CashFlowCategoryID,
                        principalTable: "GeneralLedger_CashFlowCategories",
                        principalColumn: "CashFlowCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_AccountsDetails_GeneralLedger_Configurations_~",
                        column: x => x.ConfigurationType,
                        principalTable: "GeneralLedger_Configurations",
                        principalColumn: "ConfigurationType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedger_SubAccountsDetails",
                columns: table => new
                {
                    SubAccountID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountID = table.Column<int>(type: "integer", nullable: false),
                    ConfigurationType = table.Column<int>(type: "integer", nullable: false),
                    CurrentBalance = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<int>(type: "integer", nullable: false),
                    IsLocked = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedger_SubAccountsDetails", x => x.SubAccountID);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_SubAccountsDetails_GeneralLedger_AccountsDeta~",
                        column: x => x.AccountID,
                        principalTable: "GeneralLedger_AccountsDetails",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralLedger_SubAccountsDetails_GeneralLedger_Configuratio~",
                        column: x => x.ConfigurationType,
                        principalTable: "GeneralLedger_Configurations",
                        principalColumn: "ConfigurationType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_AccountsDetails_AccountClassID",
                table: "GeneralLedger_AccountsDetails",
                column: "AccountClassID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_AccountsDetails_CashFlowCategoryID",
                table: "GeneralLedger_AccountsDetails",
                column: "CashFlowCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_AccountsDetails_ConfigurationType",
                table: "GeneralLedger_AccountsDetails",
                column: "ConfigurationType");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_CashFlowCategories_AccountTypeID",
                table: "GeneralLedger_CashFlowCategories",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_SubAccountsDetails_AccountID",
                table: "GeneralLedger_SubAccountsDetails",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedger_SubAccountsDetails_ConfigurationType",
                table: "GeneralLedger_SubAccountsDetails",
                column: "ConfigurationType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Banks_Banks");

            migrationBuilder.DropTable(
                name: "GeneralLedger_FiscalPeriods");

            migrationBuilder.DropTable(
                name: "GeneralLedger_JournalVouchers");

            migrationBuilder.DropTable(
                name: "GeneralLedger_LetterCases");

            migrationBuilder.DropTable(
                name: "GeneralLedger_SubAccountsDetails");

            migrationBuilder.DropTable(
                name: "PaymentModes_PaymentModeCategories");

            migrationBuilder.DropTable(
                name: "PaymentModes_PaymentModes");

            migrationBuilder.DropTable(
                name: "PaymentModes_PaymentModeSelectionLevels");

            migrationBuilder.DropTable(
                name: "PaymentModes_Payments");

            migrationBuilder.DropTable(
                name: "PaymentModes_SubAccounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GeneralLedger_AccountsDetails");

            migrationBuilder.DropTable(
                name: "GeneralLedger_AccountClasses");

            migrationBuilder.DropTable(
                name: "GeneralLedger_CashFlowCategories");

            migrationBuilder.DropTable(
                name: "GeneralLedger_Configurations");

            migrationBuilder.DropTable(
                name: "GeneralLedger_AccountTypes");
        }
    }
}
