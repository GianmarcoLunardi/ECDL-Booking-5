using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelsIdentity
{
    public partial class Relazione_exam_examiner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExaminerId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ExaminerId1",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExaminerId1",
                table: "Exams",
                column: "ExaminerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_ExaminerId1",
                table: "Exams",
                column: "ExaminerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_ExaminerId1",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExaminerId1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExaminerId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExaminerId1",
                table: "Exams");
        }
    }
}


/*
 Viene inserita la relazione sulla tabella exam , la rrelazione esaminatore
 La tabella exam ha una poroprietà examine di tipo applicationuser che rappresenta l esaminatore 1:1
 */