using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantPM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateddbtoincluderole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectRole",
                table: "ProjectMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectRole",
                table: "ProjectMembers");
        }
    }
}
