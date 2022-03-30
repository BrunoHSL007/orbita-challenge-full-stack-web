using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ra",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ra",
                table: "Student",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
