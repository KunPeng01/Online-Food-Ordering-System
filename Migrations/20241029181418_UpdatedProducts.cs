using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Provider_ProviderUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProviderUserId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProviderUserId",
                table: "Product",
                newName: "ProviderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProviderID",
                table: "Product",
                newName: "ProviderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProviderUserId",
                table: "Product",
                column: "ProviderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Provider_ProviderUserId",
                table: "Product",
                column: "ProviderUserId",
                principalTable: "Provider",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
