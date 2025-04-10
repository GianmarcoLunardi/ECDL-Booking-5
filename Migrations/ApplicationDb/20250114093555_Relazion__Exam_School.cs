using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelsIdentity
{
    public partial class Relazion__Exam_School : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdSchool",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Schoolid",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams",
                column: "Schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IdSchool",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "Exams");
        }
    }
}
