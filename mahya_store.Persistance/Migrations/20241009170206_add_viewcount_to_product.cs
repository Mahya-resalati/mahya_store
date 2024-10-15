using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mahya_store.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class add_viewcount_to_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");
        }
    }
}
