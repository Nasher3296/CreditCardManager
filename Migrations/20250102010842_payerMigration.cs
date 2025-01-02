using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardManager.Migrations
{
    /// <inheritdoc />
    public partial class payerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payer",
                table: "Movements");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PayerId",
                table: "Movements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_PayerId",
                table: "Movements",
                column: "PayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Payer_PayerId",
                table: "Movements",
                column: "PayerId",
                principalTable: "Payer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Payer_PayerId",
                table: "Movements");

            migrationBuilder.DropTable(
                name: "Payer");

            migrationBuilder.DropIndex(
                name: "IX_Movements_PayerId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "PayerId",
                table: "Movements");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payer",
                table: "Movements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
