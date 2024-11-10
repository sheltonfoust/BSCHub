using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialWorkApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserHoldsProviderName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Providers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
