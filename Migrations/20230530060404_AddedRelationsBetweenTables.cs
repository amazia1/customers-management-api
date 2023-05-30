using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers_Management.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationsBetweenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Contracts_ContractId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ContractId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Usage",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContractPackage",
                columns: table => new
                {
                    ContractsId = table.Column<int>(type: "int", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPackage", x => new { x.ContractsId, x.PackagesId });
                    table.ForeignKey(
                        name: "FK_ContractPackage_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractPackage_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractPackage_PackagesId",
                table: "ContractPackage",
                column: "PackagesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractPackage");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ContractId",
                table: "Packages",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Contracts_ContractId",
                table: "Packages",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}
