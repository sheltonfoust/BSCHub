using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ISP_Years : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISP_MeetingDates_Calendars_ISP_CalendarId",
                table: "ISP_MeetingDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ISP_YearStartDates_Calendars_ISP_CalendarId",
                table: "ISP_YearStartDates");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.CreateTable(
                name: "ISP_Years",
                columns: table => new
                {
                    CalendarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISP_Years", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_ISP_Years_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ISP_Years_ClientId",
                table: "ISP_Years",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_MeetingDates_ISP_Years_ISP_CalendarId",
                table: "ISP_MeetingDates",
                column: "ISP_CalendarId",
                principalTable: "ISP_Years",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_YearStartDates_ISP_Years_ISP_CalendarId",
                table: "ISP_YearStartDates",
                column: "ISP_CalendarId",
                principalTable: "ISP_Years",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISP_MeetingDates_ISP_Years_ISP_CalendarId",
                table: "ISP_MeetingDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ISP_YearStartDates_ISP_Years_ISP_CalendarId",
                table: "ISP_YearStartDates");

            migrationBuilder.DropTable(
                name: "ISP_Years");

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_Calendars_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_ClientId",
                table: "Calendars",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_MeetingDates_Calendars_ISP_CalendarId",
                table: "ISP_MeetingDates",
                column: "ISP_CalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_YearStartDates_Calendars_ISP_CalendarId",
                table: "ISP_YearStartDates",
                column: "ISP_CalendarId",
                principalTable: "Calendars",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
