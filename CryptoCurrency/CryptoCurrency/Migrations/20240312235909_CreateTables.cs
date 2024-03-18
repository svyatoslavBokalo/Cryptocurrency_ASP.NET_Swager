using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoCurrency.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supply = table.Column<double>(type: "float", nullable: true),
                    MaxSupply = table.Column<double>(type: "float", nullable: true),
                    MarketCapUsd = table.Column<double>(type: "float", nullable: true),
                    VolumeUsd24Hr = table.Column<double>(type: "float", nullable: true),
                    PriceUsd = table.Column<double>(type: "float", nullable: true),
                    ChangePercent24Hr = table.Column<double>(type: "float", nullable: true),
                    Vwap24Hr = table.Column<double>(type: "float", nullable: true),
                    action = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptocurrencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeletedCryptocurrencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCrypto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedCryptocurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeletedCryptocurrencies_Cryptocurrencies_IdCrypto",
                        column: x => x.IdCrypto,
                        principalTable: "Cryptocurrencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeletedCryptocurrencies_IdCrypto",
                table: "DeletedCryptocurrencies",
                column: "IdCrypto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeletedCryptocurrencies");

            migrationBuilder.DropTable(
                name: "Cryptocurrencies");
        }
    }
}
