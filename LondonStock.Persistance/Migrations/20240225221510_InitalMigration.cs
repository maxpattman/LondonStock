using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LondonStock.Persistance.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Ticker);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrokerID = table.Column<string>(type: "text", nullable: false),
                    StockSoldTicker = table.Column<string>(type: "text", nullable: false),
                    SoldPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Stocks_StockSoldTicker",
                        column: x => x.StockSoldTicker,
                        principalTable: "Stocks",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Ticker", "DateCreated", "Id", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { "frw", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStock2", "350" },
                    { "sas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStock", "500" },
                    { "sat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testStock3", "500" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StockSoldTicker",
                table: "Transactions",
                column: "StockSoldTicker");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
