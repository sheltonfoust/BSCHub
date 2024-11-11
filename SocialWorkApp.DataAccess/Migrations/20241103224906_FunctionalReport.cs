using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FunctionalReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Clients_ClientId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Reports",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Reports",
                newName: "ISP_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ClientId",
                table: "Reports",
                newName: "IX_Reports_ISP_YearId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CompletedDate",
                table: "Reports",
                type: "date",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ISP_Years_ISP_YearId",
                table: "Reports",
                column: "ISP_YearId",
                principalTable: "ISP_Years",
                principalColumn: "ISP_YearId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ISP_Years_ISP_YearId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Reports",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ISP_YearId",
                table: "Reports",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ISP_YearId",
                table: "Reports",
                newName: "IX_Reports_ClientId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Reports",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Clients_ClientId",
                table: "Reports",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
