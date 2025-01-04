using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardManager.Migrations
{
    /// <inheritdoc />
    public partial class bankMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Payer_PayerId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payer",
                table: "Payer");

            migrationBuilder.DropColumn(
                name: "Card",
                table: "Movements");

            migrationBuilder.RenameTable(
                name: "Payer",
                newName: "Payers");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Movements",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payers",
                table: "Payers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_CardId",
                table: "Movements",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BankId",
                table: "Cards",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Cards_CardId",
                table: "Movements",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Payers_PayerId",
                table: "Movements",
                column: "PayerId",
                principalTable: "Payers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Cards_CardId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Payers_PayerId",
                table: "Movements");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Movements_CardId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payers",
                table: "Payers");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Movements");

            migrationBuilder.RenameTable(
                name: "Payers",
                newName: "Payer");

            migrationBuilder.AddColumn<string>(
                name: "Card",
                table: "Movements",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payer",
                table: "Payer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Payer_PayerId",
                table: "Movements",
                column: "PayerId",
                principalTable: "Payer",
                principalColumn: "Id");
        }
    }
}
