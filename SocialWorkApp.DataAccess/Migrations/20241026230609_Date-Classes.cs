using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DateClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ISP_MeetingDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ISP_CalendarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISP_MeetingDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISP_MeetingDates_Calendars_ISP_CalendarId",
                        column: x => x.ISP_CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISP_YearStartDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ISP_CalendarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISP_YearStartDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISP_YearStartDates_Calendars_ISP_CalendarId",
                        column: x => x.ISP_CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ISP_MeetingDates_ISP_CalendarId",
                table: "ISP_MeetingDates",
                column: "ISP_CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_ISP_YearStartDates_ISP_CalendarId",
                table: "ISP_YearStartDates",
                column: "ISP_CalendarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ISP_MeetingDates");

            migrationBuilder.DropTable(
                name: "ISP_YearStartDates");
        }
    }
}
