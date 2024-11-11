using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ISP_MeetingDates");

            migrationBuilder.DropTable(
                name: "ISP_YearStartDates");

            migrationBuilder.AddColumn<DateOnly>(
                name: "MeetingDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "ISP_Years",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ISP_Years");

            migrationBuilder.CreateTable(
                name: "ISP_MeetingDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISP_YearId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Defined = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISP_MeetingDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISP_MeetingDates_ISP_Years_ISP_YearId",
                        column: x => x.ISP_YearId,
                        principalTable: "ISP_Years",
                        principalColumn: "ISP_YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISP_YearStartDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISP_YearId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Defined = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISP_YearStartDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISP_YearStartDates_ISP_Years_ISP_YearId",
                        column: x => x.ISP_YearId,
                        principalTable: "ISP_Years",
                        principalColumn: "ISP_YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ISP_MeetingDates_ISP_YearId",
                table: "ISP_MeetingDates",
                column: "ISP_YearId");

            migrationBuilder.CreateIndex(
                name: "IX_ISP_YearStartDates_ISP_YearId",
                table: "ISP_YearStartDates",
                column: "ISP_YearId");
        }
    }
}
