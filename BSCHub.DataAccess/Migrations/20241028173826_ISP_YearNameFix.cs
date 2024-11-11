using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ISP_YearNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISP_MeetingDates_ISP_Years_ISP_CalendarId",
                table: "ISP_MeetingDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ISP_YearStartDates_ISP_Years_ISP_CalendarId",
                table: "ISP_YearStartDates");

            migrationBuilder.RenameColumn(
                name: "ISP_CalendarId",
                table: "ISP_YearStartDates",
                newName: "ISP_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_ISP_YearStartDates_ISP_CalendarId",
                table: "ISP_YearStartDates",
                newName: "IX_ISP_YearStartDates_ISP_YearId");

            migrationBuilder.RenameColumn(
                name: "ISP_CalendarId",
                table: "ISP_MeetingDates",
                newName: "ISP_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_ISP_MeetingDates_ISP_CalendarId",
                table: "ISP_MeetingDates",
                newName: "IX_ISP_MeetingDates_ISP_YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_MeetingDates_ISP_Years_ISP_YearId",
                table: "ISP_MeetingDates",
                column: "ISP_YearId",
                principalTable: "ISP_Years",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ISP_YearStartDates_ISP_Years_ISP_YearId",
                table: "ISP_YearStartDates",
                column: "ISP_YearId",
                principalTable: "ISP_Years",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISP_MeetingDates_ISP_Years_ISP_YearId",
                table: "ISP_MeetingDates");

            migrationBuilder.DropForeignKey(
                name: "FK_ISP_YearStartDates_ISP_Years_ISP_YearId",
                table: "ISP_YearStartDates");

            migrationBuilder.RenameColumn(
                name: "ISP_YearId",
                table: "ISP_YearStartDates",
                newName: "ISP_CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_ISP_YearStartDates_ISP_YearId",
                table: "ISP_YearStartDates",
                newName: "IX_ISP_YearStartDates_ISP_CalendarId");

            migrationBuilder.RenameColumn(
                name: "ISP_YearId",
                table: "ISP_MeetingDates",
                newName: "ISP_CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_ISP_MeetingDates_ISP_YearId",
                table: "ISP_MeetingDates",
                newName: "IX_ISP_MeetingDates_ISP_CalendarId");

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
    }
}
