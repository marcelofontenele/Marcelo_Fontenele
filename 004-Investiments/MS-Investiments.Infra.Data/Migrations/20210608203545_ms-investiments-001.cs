using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_Investiments.Infra.Data.Migrations
{
    public partial class msinvestiments001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Toro");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false, defaultValue: 0m),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false, defaultValue: 0m),
                    Symbol = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Toro",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                schema: "Toro",
                table: "Orders",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Toro");
        }
    }
}
