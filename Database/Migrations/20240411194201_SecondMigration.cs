using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioURL",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverURL",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PdfURL",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "ListenAudioBookPages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "Bookpreviews",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "Bookpreviews",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallCoverImg",
                table: "Bookpreviews",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BigCoverImg",
                table: "BookPages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "BookPages",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "ListenAudioBookPages");

            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "Bookpreviews");

            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "Bookpreviews");

            migrationBuilder.DropColumn(
                name: "SmallCoverImg",
                table: "Bookpreviews");

            migrationBuilder.DropColumn(
                name: "BigCoverImg",
                table: "BookPages");

            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "BookPages");

            migrationBuilder.AddColumn<string>(
                name: "AudioURL",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverURL",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PdfURL",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }
    }
}
