using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcDemo.Migrations
{
    public partial class ModifyIdentity_AddCol_City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "MvcDemo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "MvcDemo",
                table: "AspNetUsers");
        }
    }
}
