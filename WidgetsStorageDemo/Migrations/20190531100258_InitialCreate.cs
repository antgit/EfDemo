using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WidgetsStorageDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WidgetVariations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetVariations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidgetStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WidgetVariationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetStates_WidgetVariations_WidgetVariationId",
                        column: x => x.WidgetVariationId,
                        principalTable: "WidgetVariations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetContainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WidgetStateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetContainers_WidgetStates_WidgetStateId",
                        column: x => x.WidgetStateId,
                        principalTable: "WidgetStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WidgetComponents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WidgetContainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetComponents_WidgetContainers_WidgetContainerId",
                        column: x => x.WidgetContainerId,
                        principalTable: "WidgetContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WidgetComponents_WidgetContainerId",
                table: "WidgetComponents",
                column: "WidgetContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetContainers_WidgetStateId",
                table: "WidgetContainers",
                column: "WidgetStateId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetStates_WidgetVariationId",
                table: "WidgetStates",
                column: "WidgetVariationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WidgetComponents");

            migrationBuilder.DropTable(
                name: "WidgetContainers");

            migrationBuilder.DropTable(
                name: "WidgetStates");

            migrationBuilder.DropTable(
                name: "WidgetVariations");
        }
    }
}
