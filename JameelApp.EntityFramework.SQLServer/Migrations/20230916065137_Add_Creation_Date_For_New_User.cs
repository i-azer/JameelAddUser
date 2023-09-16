using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JameelApp.EntityFramework.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class Add_Creation_Date_For_New_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "Jameel",
                table: "JameelUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 16, 6, 51, 37, 696, DateTimeKind.Utc).AddTicks(7571));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "Jameel",
                table: "JameelUsers");
        }
    }
}
