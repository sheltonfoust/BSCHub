using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProviderToConsultant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsProvider",
                table: "Users",
                newName: "IsConsultant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsConsultant",
                table: "Users",
                newName: "IsProvider");
        }
    }
}
