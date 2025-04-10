using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelsIdentity
{
    public partial class School_User_inseriemnto_relazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdSchool",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Schoolid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdSchool",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "AspNetUsers");
        }
    }
}
