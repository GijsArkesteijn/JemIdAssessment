using Microsoft.EntityFrameworkCore.Migrations;

namespace jimid.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artiekel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", maxLength: 13, nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Potmaat = table.Column<int>(type: "INTEGER", nullable: false),
                    Planthoogte = table.Column<int>(type: "INTEGER", nullable: false),
                    Kleur = table.Column<string>(type: "TEXT", nullable: true),
                    Productgroep = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artiekel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artiekel",
                columns: new[] { "Id", "Kleur", "Naam", "Planthoogte", "Potmaat", "Productgroep" },
                values: new object[] { 1, "Rood", "plan1", 3, 4, "Tulpen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artiekel");
        }
    }
}
