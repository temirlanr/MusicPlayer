using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlayer.DataLayer.Migrations
{
    public partial class AddedFileLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileLength",
                table: "Songs",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileLength",
                table: "Songs");
        }
    }
}
