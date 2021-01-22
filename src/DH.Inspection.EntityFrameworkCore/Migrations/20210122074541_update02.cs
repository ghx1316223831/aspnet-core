using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DH.Inspection.Migrations
{
    public partial class update02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Inspections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Inspections",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Inspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Inspections");
        }
    }
}
