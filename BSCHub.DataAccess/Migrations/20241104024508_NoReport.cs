using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NoReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportEntities");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BCIP_CompletedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BCIP_ReviewedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBCIP",
                table: "ISP_Years",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPPMP",
                table: "ISP_Years",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PBSA_CompletedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PBSA_ReviewedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PBSP_CompletedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PBSP_ReviewedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PPMP_CompletedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "PPMP_ReviewedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "SemiAnnCompletedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "SemiAnnReviewedDate",
                table: "ISP_Years",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BCIP_CompletedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "BCIP_ReviewedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "HasBCIP",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "HasPPMP",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PBSA_CompletedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PBSA_ReviewedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PBSP_CompletedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PBSP_ReviewedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PPMP_CompletedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "PPMP_ReviewedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "SemiAnnCompletedDate",
                table: "ISP_Years");

            migrationBuilder.DropColumn(
                name: "SemiAnnReviewedDate",
                table: "ISP_Years");

            migrationBuilder.CreateTable(
                name: "ReportEntities",
                columns: table => new
                {
                    ReportEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISP_YearId = table.Column<int>(type: "integer", nullable: false),
                    CompletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ReviewedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportEntities", x => x.ReportEntityId);
                    table.ForeignKey(
                        name: "FK_ReportEntities_ISP_Years_ISP_YearId",
                        column: x => x.ISP_YearId,
                        principalTable: "ISP_Years",
                        principalColumn: "ISP_YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportEntities_ISP_YearId",
                table: "ReportEntities",
                column: "ISP_YearId");
        }
    }
}
