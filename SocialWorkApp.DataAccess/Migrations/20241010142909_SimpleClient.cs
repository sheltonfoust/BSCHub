using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SimpleClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasReportInfo",
                table: "Clients");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ISP_YearStartDate",
                table: "Clients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISP_YearStartDate",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "HasReportInfo",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
