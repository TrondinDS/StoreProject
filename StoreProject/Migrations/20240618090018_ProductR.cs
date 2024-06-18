using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProject.Migrations
{
    /// <inheritdoc />
    public partial class ProductR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInformation_Products_ProductId",
                table: "ProductInformation");

            migrationBuilder.DropIndex(
                name: "IX_ProductInformation_ProductId",
                table: "ProductInformation");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductInformation",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInformation_ProductId",
                table: "ProductInformation",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInformation_Products_ProductId",
                table: "ProductInformation",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
