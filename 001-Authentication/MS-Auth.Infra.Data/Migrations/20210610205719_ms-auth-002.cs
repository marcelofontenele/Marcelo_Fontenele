using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_Auth.Infra.Data.Migrations
{
    public partial class msauth002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO [Toro].[Users](Id, Name, CPF, Login, Password, Active)
                VALUES (1, 'Fulano Silva', '45358996060', 'user', '123456', 1)
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
