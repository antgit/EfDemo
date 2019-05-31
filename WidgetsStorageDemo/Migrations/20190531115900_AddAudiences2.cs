using Microsoft.EntityFrameworkCore.Migrations;

namespace WidgetsStorageDemo.Migrations
{
    public partial class AddAudiences2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WidgetAudience",
                table: "WidgetAudience");

            migrationBuilder.RenameTable(
                name: "WidgetAudience",
                newName: "WidgetAudiences");

            migrationBuilder.RenameIndex(
                name: "IX_WidgetAudience_WidgetVariationId",
                table: "WidgetAudiences",
                newName: "IX_WidgetAudiences_WidgetVariationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WidgetAudiences",
                table: "WidgetAudiences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetAudiences_WidgetVariations_WidgetVariationId",
                table: "WidgetAudiences",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetAudiences_WidgetVariations_WidgetVariationId",
                table: "WidgetAudiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WidgetAudiences",
                table: "WidgetAudiences");

            migrationBuilder.RenameTable(
                name: "WidgetAudiences",
                newName: "WidgetAudience");

            migrationBuilder.RenameIndex(
                name: "IX_WidgetAudiences_WidgetVariationId",
                table: "WidgetAudience",
                newName: "IX_WidgetAudience_WidgetVariationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WidgetAudience",
                table: "WidgetAudience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
