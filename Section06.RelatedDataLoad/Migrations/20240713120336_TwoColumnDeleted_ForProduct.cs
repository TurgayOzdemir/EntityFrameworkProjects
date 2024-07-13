using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Section06.RelatedDataLoad.Migrations
{
    /// <inheritdoc />
    public partial class TwoColumnDeleted_ForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceKdv",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Kdv",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kdv",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceKdv",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[Price]*[Kdv]");
        }
    }
}
