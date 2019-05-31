using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WidgetsStorageDemo.Migrations
{
    public partial class AddAudiences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WidgetAudience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    WidgetVariationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetAudience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetAudience_WidgetVariations_WidgetVariationId",
                        column: x => x.WidgetVariationId,
                        principalTable: "WidgetVariations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WidgetAudience_WidgetVariationId",
                table: "WidgetAudience",
                column: "WidgetVariationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WidgetAudience");
        }
    }
}
