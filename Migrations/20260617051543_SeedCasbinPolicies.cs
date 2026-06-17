using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPortal.Migrations
{
    /// <inheritdoc />
    public partial class SeedCasbinPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CasbinRules",
                columns: new[]
                {
                    "PType",
                    "V0",
                    "V1",
                    "V2"
                },
                values: new object[,]
                {
                    { "p", "Admin", "Project", "Create" },
                    { "p", "Admin", "Project", "Update" },
                    { "p", "Admin", "Project", "Delete" },

                    { "p", "Admin", "User", "Create" },
                    { "p", "Admin", "User", "Update" },
                    { "p", "Admin", "User", "Delete" },

                    { "p", "Manager", "Task", "Create" },
                    { "p", "Manager", "Task", "Update" },

                    { "p", "Employee", "Project", "Read" },
                    { "p", "Employee", "Task", "Read" },

                    { "g", "Admin", "Manager", "" },
                    { "g", "Manager", "Employee", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DELETE FROM ""CasbinRules""
                  WHERE ""PType"" IN ('p','g')");
        }
    }
}
