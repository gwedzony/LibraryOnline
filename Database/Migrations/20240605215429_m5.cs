using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Books_BooksBookId",
                table: "BookCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Collections_CollectionsCollectionId",
                table: "BookCollections");

            migrationBuilder.DropTable(
                name: "BookPreviewCollections");

            migrationBuilder.DropTable(
                name: "BookPreviewNewests");

            migrationBuilder.DropTable(
                name: "ListenAudioBookPages");

            migrationBuilder.DropTable(
                name: "ReadOnlineBooks");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CollectionsCollectionId",
                table: "BookCollections",
                newName: "CollectionId");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "BookCollections",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCollections_CollectionsCollectionId",
                table: "BookCollections",
                newName: "IX_BookCollections_CollectionId");

            migrationBuilder.AddColumn<int>(
                name: "BookNewsCardId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "BookPages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuthorPages",
                columns: table => new
                {
                    AuthorPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPages", x => x.AuthorPageId);
                    table.ForeignKey(
                        name: "FK_AuthorPages_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookNewsCards",
                columns: table => new
                {
                    BookNewsCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SmallCoverImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WhenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookNewsCards", x => x.BookNewsCardId);
                    table.ForeignKey(
                        name: "FK_BookNewsCards_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPages_AuthorId",
                table: "AuthorPages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookNewsCards_BookId",
                table: "BookNewsCards",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Books_BookId",
                table: "BookCollections",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Collections_CollectionId",
                table: "BookCollections",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Books_BookId",
                table: "BookCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Collections_CollectionId",
                table: "BookCollections");

            migrationBuilder.DropTable(
                name: "AuthorPages");

            migrationBuilder.DropTable(
                name: "BookNewsCards");

            migrationBuilder.DropColumn(
                name: "BookNewsCardId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "BookPages");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "BookCollections",
                newName: "CollectionsCollectionId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookCollections",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookCollections_CollectionId",
                table: "BookCollections",
                newName: "IX_BookCollections_CollectionsCollectionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "Books",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BookPreviewCollections",
                columns: table => new
                {
                    PreviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    AudioUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PdfUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SmallCoverImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPreviewCollections", x => x.PreviewId);
                    table.ForeignKey(
                        name: "FK_BookPreviewCollections_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_BookPreviewCollections_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookPreviewNewests",
                columns: table => new
                {
                    NewestBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    BookLink = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SmallCoverImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPreviewNewests", x => x.NewestBookId);
                    table.ForeignKey(
                        name: "FK_BookPreviewNewests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListenAudioBookPages",
                columns: table => new
                {
                    AudioPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    AudioUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenAudioBookPages", x => x.AudioPageId);
                    table.ForeignKey(
                        name: "FK_ListenAudioBookPages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReadOnlineBooks",
                columns: table => new
                {
                    ReadOnlineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadOnlineBooks", x => x.ReadOnlineId);
                    table.ForeignKey(
                        name: "FK_ReadOnlineBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookPreviewCollections_BookId",
                table: "BookPreviewCollections",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookPreviewCollections_CollectionId",
                table: "BookPreviewCollections",
                column: "CollectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookPreviewNewests_BookId",
                table: "BookPreviewNewests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenAudioBookPages_BookId",
                table: "ListenAudioBookPages",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadOnlineBooks_BookId",
                table: "ReadOnlineBooks",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Books_BooksBookId",
                table: "BookCollections",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Collections_CollectionsCollectionId",
                table: "BookCollections",
                column: "CollectionsCollectionId",
                principalTable: "Collections",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
