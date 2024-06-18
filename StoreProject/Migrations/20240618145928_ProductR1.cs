using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProject.Migrations
{
    /// <inheritdoc />
    public partial class ProductR1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrdersItem",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrdersItem",
                newName: "OrderItemId");
        }
    }
}
