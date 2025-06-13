using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Migrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionApplication_MissionThemes_MissionThemeId",
                table: "MissionApplication");

            migrationBuilder.DropIndex(
                name: "IX_MissionApplication_MissionThemeId",
                table: "MissionApplication");

            migrationBuilder.DropColumn(
                name: "MissionThemeId",
                table: "MissionApplication");

            migrationBuilder.DropColumn(
                name: "MissionTitle",
                table: "MissionApplication");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissionThemeId",
                table: "MissionApplication",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MissionTitle",
                table: "MissionApplication",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MissionApplication_MissionThemeId",
                table: "MissionApplication",
                column: "MissionThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionApplication_MissionThemes_MissionThemeId",
                table: "MissionApplication",
                column: "MissionThemeId",
                principalTable: "MissionThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
