using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity2.Migrations
{
    public partial class Exam_aad_Col_Bookable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bookable",
                table: "Exams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bookable",
                table: "Exams");
        }
    }
}
