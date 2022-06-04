using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingScheduler.Migrations
{
    public partial class UpdateScriptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "script",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "script",
                newName: "ScriptID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "script",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ScriptID",
                table: "script",
                newName: "id");
        }
    }
}
