using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TH01.Migrations
{
    /// <inheritdoc />
    public partial class addShoppingCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCartItems_Products_ProductsId",
                table: "shoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shoppingCartItems",
                table: "shoppingCartItems");

            migrationBuilder.RenameTable(
                name: "shoppingCartItems",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ShoppingCartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_shoppingCartItems_ProductsId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "shoppingCartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "shoppingCartItems",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "shoppingCartItems",
                newName: "IX_shoppingCartItems_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoppingCartItems",
                table: "shoppingCartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCartItems_Products_ProductsId",
                table: "shoppingCartItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
