using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Repository.Migrations
{
    public partial class Refact_to2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Peoples",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_UsersId",
                table: "Peoples",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_Users_UsersId",
                table: "Peoples",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_Users_UsersId",
                table: "Peoples");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_UsersId",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Peoples");

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
    }
}
