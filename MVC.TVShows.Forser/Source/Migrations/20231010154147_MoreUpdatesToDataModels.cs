using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.TVShows.Forser.Migrations
{
    /// <inheritdoc />
    public partial class MoreUpdatesToDataModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TVShow_Genre",
                table: "TVShow_Genre");

            migrationBuilder.RenameTable(
                name: "TVShow_Genre",
                newName: "TVShowGenres");

            migrationBuilder.RenameIndex(
                name: "IX_TVShow_Genre_TVShow_Id",
                table: "TVShowGenres",
                newName: "IX_TVShowGenres_TVShow_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TVShow_Genre_Genre_Id",
                table: "TVShowGenres",
                newName: "IX_TVShowGenres_Genre_Id");

            migrationBuilder.AlterColumn<int>(
                name: "TVShow_Id",
                table: "TVShowGenres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Genre_Id",
                table: "TVShowGenres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TVShowGenres",
                table: "TVShowGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowGenres_Genres_Genre_Id",
                table: "TVShowGenres",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShowGenres_TVShows_TVShow_Id",
                table: "TVShowGenres",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TVShowGenres_Genres_Genre_Id",
                table: "TVShowGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_TVShowGenres_TVShows_TVShow_Id",
                table: "TVShowGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TVShowGenres",
                table: "TVShowGenres");

            migrationBuilder.RenameTable(
                name: "TVShowGenres",
                newName: "TVShow_Genre");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowGenres_TVShow_Id",
                table: "TVShow_Genre",
                newName: "IX_TVShow_Genre_TVShow_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TVShowGenres_Genre_Id",
                table: "TVShow_Genre",
                newName: "IX_TVShow_Genre_Genre_Id");

            migrationBuilder.AlterColumn<int>(
                name: "TVShow_Id",
                table: "TVShow_Genre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Genre_Id",
                table: "TVShow_Genre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TVShow_Genre",
                table: "TVShow_Genre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_Genres_Genre_Id",
                table: "TVShow_Genre",
                column: "Genre_Id",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TVShow_Genre_TVShows_TVShow_Id",
                table: "TVShow_Genre",
                column: "TVShow_Id",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
