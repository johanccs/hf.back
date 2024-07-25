using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hf.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyInvoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "InvoiceHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "InvoiceHeaders");
        }
    }
}
