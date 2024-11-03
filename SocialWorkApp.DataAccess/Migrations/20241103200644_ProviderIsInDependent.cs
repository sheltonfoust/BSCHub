using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProviderIsInDependent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndependent",
                table: "Providers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndependent",
                table: "Providers");
        }
    }
}
