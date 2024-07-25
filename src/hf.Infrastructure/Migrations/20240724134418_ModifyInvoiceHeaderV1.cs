using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hf.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyInvoiceHeaderV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "InvoiceLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "InvoiceHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "InvoiceLines",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId",
                table: "InvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "InvoiceHeaders",
                principalColumn: "Id");
        }
    }
}
