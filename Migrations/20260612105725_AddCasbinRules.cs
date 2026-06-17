using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddCasbinRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasbinRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PType = table.Column<string>(type: "text", nullable: false),
                    V0 = table.Column<string>(type: "text", nullable: false),
                    V1 = table.Column<string>(type: "text", nullable: false),
                    V2 = table.Column<string>(type: "text", nullable: false),
                    V3 = table.Column<string>(type: "text", nullable: true),
                    V4 = table.Column<string>(type: "text", nullable: true),
                    V5 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasbinRules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasbinRules");
        }
    }
}
