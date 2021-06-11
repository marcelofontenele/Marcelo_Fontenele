using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_User.Infra.Data.Migrations
{
    public partial class msuser002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO [Toro].[Users] (CPF, [Name])
                VALUES ('45358996060', 'Fulano Silva')
                GO

                INSERT INTO [Toro].[Accounts] (UserId)
                VALUES (@@Identity)
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
