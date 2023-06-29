using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeAPITest.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimesTamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sucess = table.Column<bool>(type: "bit", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Simbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CurrencyResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_Currencys_CurrencyResponseId",
                        column: x => x.CurrencyResponseId,
                        principalTable: "Currencys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CurrencyResponseId",
                table: "Currency",
                column: "CurrencyResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Currencys");
        }
    }
}
