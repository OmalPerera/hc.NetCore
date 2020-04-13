using Microsoft.EntityFrameworkCore.Migrations;

namespace HC_netCore.Migrations
{
    public partial class notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TodoItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TodoItem");
        }
    }
}
