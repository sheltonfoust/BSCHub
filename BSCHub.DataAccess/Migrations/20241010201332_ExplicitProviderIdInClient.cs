using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSCHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitProviderIdInClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Providers_ProviderId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Providers_ProviderId",
                table: "Clients",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Providers_ProviderId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Clients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Providers_ProviderId",
                table: "Clients",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId");
        }
    }
}
