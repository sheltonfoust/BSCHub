using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProviderDependOnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Providers_ProviderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProviderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Providers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_UserId",
                table: "Providers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Users_UserId",
                table: "Providers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Users_UserId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_UserId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Providers");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProviderId",
                table: "Users",
                column: "ProviderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Providers_ProviderId",
                table: "Users",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId");
        }
    }
}
