using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexAndcreateIdCardAsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdCard",
                table: "Customers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdCard",
                table: "Customers",
                column: "IdCard",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_IdCard",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "IdCard",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);
        }
    }
}
