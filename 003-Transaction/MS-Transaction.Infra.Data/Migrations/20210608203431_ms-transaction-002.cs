using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_Transaction.Infra.Data.Migrations
{
    public partial class mstransaction002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO [Toro].[Users]
                VALUES(1, '45358996060', GETDATE())
                GO

                INSERT INTO [Toro].[Accounts]
                VALUES (1, 1, GETDATE())
                GO"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
