using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReportEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.CreateTable(
                name: "ReportEntities",
                columns: table => new
                {
                    ReportEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ReviewedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ISP_YearId = table.Column<int>(type: "integer", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportEntities");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISP_YearId = table.Column<int>(type: "integer", nullable: false),
                    CompletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ReviewedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_ISP_Years_ISP_YearId",
                        column: x => x.ISP_YearId,
                        principalTable: "ISP_Years",
                        principalColumn: "ISP_YearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ISP_YearId",
                table: "Reports",
                column: "ISP_YearId");
        }
    }
}
