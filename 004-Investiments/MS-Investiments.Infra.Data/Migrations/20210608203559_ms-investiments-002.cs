using Microsoft.EntityFrameworkCore.Migrations;

namespace MS_Investiments.Infra.Data.Migrations
{
    public partial class msinvestiments002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            
                INSERT INTO Toro.Accounts(Id, UserId)
                VALUES(1,1)
                GO

                INSERT INTO Toro.Stocks
                VALUES
                ('PETR4', 28.44),
                ('MGLU3', 25.91),
                ('VVAR3', 25.91),
                ('SANB11', 40.77),
                ('TORO4', 115.98)
                GO

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
