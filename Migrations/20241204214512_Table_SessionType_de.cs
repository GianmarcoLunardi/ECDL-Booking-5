using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity2.Migrations
{
    public partial class Table_SessionType_de : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeDe",
                table: "SessionTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeDe",
                table: "SessionTypes");
        }
    }
}


//   correzione della tabeòòa Sessione  type
//vieme aggiunto una colonna per il tedesco