using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "BookPreviewCollections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookPreviewCollections_CollectionId",
                table: "BookPreviewCollections",
                column: "CollectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookPreviewCollections_Collections_CollectionId",
                table: "BookPreviewCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPreviewCollections_Collections_CollectionId",
                table: "BookPreviewCollections");

            migrationBuilder.DropIndex(
                name: "IX_BookPreviewCollections_CollectionId",
                table: "BookPreviewCollections");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "BookPreviewCollections");
        }
    }
}
