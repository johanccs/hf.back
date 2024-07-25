using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hf.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_ValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHeaders_UserId_ClientIdId",
                table: "InvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_ProductId_ProductIdId",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_UserId_ClientIdId",
                table: "InvoiceLines");

            migrationBuilder.DropTable(
                name: "ProductId");

            migrationBuilder.DropTable(
                name: "UserId");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_ClientIdId",
                table: "InvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLines_ProductIdId",
                table: "InvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHeaders_ClientIdId",
                table: "InvoiceHeaders");

            migrationBuilder.RenameColumn(
                name: "ProductIdId",
                table: "InvoiceLines",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ClientIdId",
                table: "InvoiceLines",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientIdId",
                table: "InvoiceHeaders",
                newName: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InvoiceLines",
                newName: "ProductIdId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "InvoiceLines",
                newName: "ClientIdId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "InvoiceHeaders",
                newName: "ClientIdId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ClientIdId",
                table: "InvoiceLines",
                column: "ClientIdId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ProductIdId",
                table: "InvoiceLines",
                column: "ProductIdId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_ClientIdId",
                table: "InvoiceHeaders",
                column: "ClientIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHeaders_UserId_ClientIdId",
                table: "InvoiceHeaders",
                column: "ClientIdId",
                principalTable: "UserId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_ProductId_ProductIdId",
                table: "InvoiceLines",
                column: "ProductIdId",
                principalTable: "ProductId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_UserId_ClientIdId",
                table: "InvoiceLines",
                column: "ClientIdId",
                principalTable: "UserId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
