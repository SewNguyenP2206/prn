using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BussinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class U4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Servers_ServerId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Servers_ServerId1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ServerId1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ServerId1",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Servers_ServerId",
                table: "Categories",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Servers_ServerId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "ServerId1",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ServerId1",
                table: "Categories",
                column: "ServerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Servers_ServerId",
                table: "Categories",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Servers_ServerId1",
                table: "Categories",
                column: "ServerId1",
                principalTable: "Servers",
                principalColumn: "Id");
        }
    }
}
