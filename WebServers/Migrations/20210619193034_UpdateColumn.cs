using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServers.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AssigeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssigeeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssigeeId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AssigneeId",
                table: "Tasks",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AssigneeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssigneeId",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "AssigeeId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssigeeId",
                table: "Tasks",
                column: "AssigeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AssigeeId",
                table: "Tasks",
                column: "AssigeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
