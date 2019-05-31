using Microsoft.EntityFrameworkCore.Migrations;

namespace WidgetsStorageDemo.Migrations
{
    public partial class TableRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetComponents_WidgetContainers_WidgetContainerId",
                table: "WidgetComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetContainers_WidgetStates_WidgetStateId",
                table: "WidgetContainers");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetStates_WidgetVariations_WidgetVariationId",
                table: "WidgetStates");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetComponents_WidgetContainers_WidgetContainerId",
                table: "WidgetComponents",
                column: "WidgetContainerId",
                principalTable: "WidgetContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetContainers_WidgetStates_WidgetStateId",
                table: "WidgetContainers",
                column: "WidgetStateId",
                principalTable: "WidgetStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetStates_WidgetVariations_WidgetVariationId",
                table: "WidgetStates",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetComponents_WidgetContainers_WidgetContainerId",
                table: "WidgetComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetContainers_WidgetStates_WidgetStateId",
                table: "WidgetContainers");

            migrationBuilder.DropForeignKey(
                name: "FK_WidgetStates_WidgetVariations_WidgetVariationId",
                table: "WidgetStates");

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                table: "WidgetAudience",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetComponents_WidgetContainers_WidgetContainerId",
                table: "WidgetComponents",
                column: "WidgetContainerId",
                principalTable: "WidgetContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetContainers_WidgetStates_WidgetStateId",
                table: "WidgetContainers",
                column: "WidgetStateId",
                principalTable: "WidgetStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WidgetStates_WidgetVariations_WidgetVariationId",
                table: "WidgetStates",
                column: "WidgetVariationId",
                principalTable: "WidgetVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
