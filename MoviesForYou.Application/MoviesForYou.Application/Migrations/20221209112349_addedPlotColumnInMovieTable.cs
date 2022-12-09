using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesForYou.Application.API.Migrations
{
    public partial class addedPlotColumnInMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Movies");
        }
    }
}
