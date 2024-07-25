using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hf.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_UserId_ClientIdId",
                        column: x => x.ClientIdId,
                        principalTable: "UserId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLines_ProductId_ProductIdId",
                        column: x => x.ProductIdId,
                        principalTable: "ProductId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_UserId_ClientIdId",
                        column: x => x.ClientIdId,
                        principalTable: "UserId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_ClientIdId",
                table: "InvoiceHeaders",
                column: "ClientIdId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ClientIdId",
                table: "InvoiceLines",
                column: "ClientIdId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceHeaderId",
                table: "InvoiceLines",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ProductIdId",
                table: "InvoiceLines",
                column: "ProductIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "ProductId");

            migrationBuilder.DropTable(
                name: "UserId");
        }
    }
}
