using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProviderHasName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIndependent",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Providers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Providers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndependent",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Providers");
        }
    }
}
