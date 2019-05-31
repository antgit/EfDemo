using Microsoft.EntityFrameworkCore.Migrations;

namespace WidgetsStorageDemo.Migrations
{
    public partial class AddName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WidgetStates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WidgetContainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WidgetComponents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WidgetStates");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WidgetContainers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WidgetComponents");
        }
    }
}
