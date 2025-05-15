using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecoCms6.Data.Migrations
{
    /// <inheritdoc />
    public partial class Support2faIpLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UseIpFor2faSince",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TwofaIpAddress",
                table: "AspNetUsers",
                type: "nvarchar(45)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseIpFor2faSince",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwofaIpAddress",
                table: "AspNetUsers");
        }
    }
}