using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Repository.Migrations
{
    public partial class updatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Users_UserId",
                table: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_UserId",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Peoples");

            migrationBuilder.RenameColumn(
                name: "LasName",
                table: "Peoples",
                newName: "LastName");

            migrationBuilder.AddColumn<Guid>(
                name: "PeopleId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PeopleId",
                table: "Users",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Peoples_PeopleId",
                table: "Users",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Peoples_PeopleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PeopleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Peoples",
                newName: "LasName");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Peoples",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_UserId",
                table: "Peoples",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Users_UserId",
                table: "Peoples",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
