using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_Transaction.Infra.Data.Migrations
{
    public partial class mstransaction001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Toro");

            migrationBuilder.CreateTable(
                name: "Targets",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Account = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers_Origins",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false, defaultValue: 0m),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    OriginId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Targets_TargetId",
                        column: x => x.TargetId,
                        principalSchema: "Toro",
                        principalTable: "Targets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Transfers_Origins_OriginId",
                        column: x => x.OriginId,
                        principalSchema: "Toro",
                        principalTable: "Transfers_Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Toro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Toro",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                schema: "Toro",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_OriginId",
                schema: "Toro",
                table: "Transfers",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TargetId",
                schema: "Toro",
                table: "Transfers",
                column: "TargetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Transfers",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Targets",
                schema: "Toro");

            migrationBuilder.DropTable(
                name: "Transfers_Origins",
                schema: "Toro");
        }
    }
}
