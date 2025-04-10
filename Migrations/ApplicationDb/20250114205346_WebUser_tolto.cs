using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelsIdentity
{
    public partial class WebUser_tolto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WebUser_WebUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WebUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WebUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WebUserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Scuola",
                table: "AspNetUsers",
                newName: "familyContactPerson_phone");

            migrationBuilder.RenameColumn(
                name: "Classe",
                table: "AspNetUsers",
                newName: "familyContactPerson_email");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Born",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "familyContactPerson",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Born",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "familyContactPerson",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "familyContactPerson_phone",
                table: "AspNetUsers",
                newName: "Scuola");

            migrationBuilder.RenameColumn(
                name: "familyContactPerson_email",
                table: "AspNetUsers",
                newName: "Classe");

            migrationBuilder.AddColumn<Guid>(
                name: "WebUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WebUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familyContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familyContactPerson_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    familyContactPerson_phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WebUserId",
                table: "AspNetUsers",
                column: "WebUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WebUser_WebUserId",
                table: "AspNetUsers",
                column: "WebUserId",
                principalTable: "WebUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
