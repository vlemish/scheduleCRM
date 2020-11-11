using Microsoft.EntityFrameworkCore.Migrations;

namespace scheduleDbCore.Migrations
{
    public partial class With_Changed_Attributes_For_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Identity",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identity",
                table: "Users");
        }
    }
}
