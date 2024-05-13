using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductCategory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CustomerType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "City",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Branch",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCategory",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CustomerType",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Branch",
                newName: "id");
        }
    }
}
