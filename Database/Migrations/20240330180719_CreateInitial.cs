using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    BookTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.BookTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Colections",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colections", x => x.CollectionId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CoverURL = table.Column<string>(type: "TEXT", nullable: true),
                    PdfURL = table.Column<string>(type: "TEXT", nullable: true),
                    AudioURL = table.Column<string>(type: "TEXT", nullable: true),
                    IdAuthor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdBookType = table.Column<int>(type: "INTEGER", nullable: false),
                    IdGenre = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookTypes_IdBookType",
                        column: x => x.IdBookType,
                        principalTable: "BookTypes",
                        principalColumn: "BookTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCollections",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionsCollectionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollections", x => new { x.BooksBookId, x.CollectionsCollectionId });
                    table.ForeignKey(
                        name: "FK_BookCollections_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCollections_Colections_CollectionsCollectionId",
                        column: x => x.CollectionsCollectionId,
                        principalTable: "Colections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPages",
                columns: table => new
                {
                    BookPageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPages", x => x.BookPageId);
                    table.ForeignKey(
                        name: "FK_BookPages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookpreviews",
                columns: table => new
                {
                    PreviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookpreviews", x => x.PreviewId);
                    table.ForeignKey(
                        name: "FK_Bookpreviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "ListenAudioBookPages",
                columns: table => new
                {
                    AudioPageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenAudioBookPages", x => x.AudioPageId);
                    table.ForeignKey(
                        name: "FK_ListenAudioBookPages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "ReadOnlineBooks",
                columns: table => new
                {
                    ReadOnlineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadOnlineBooks", x => x.ReadOnlineId);
                    table.ForeignKey(
                        name: "FK_ReadOnlineBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "TableOfContents",
                columns: table => new
                {
                    tocId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableOfContents", x => x.tocId);
                    table.ForeignKey(
                        name: "FK_TableOfContents_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterNames",
                columns: table => new
                {
                    ChapterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChapterName = table.Column<string>(type: "TEXT", nullable: true),
                    ChapterNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TocId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterNames", x => x.ChapterId);
                    table.ForeignKey(
                        name: "FK_ChapterNames_TableOfContents_TocId",
                        column: x => x.TocId,
                        principalTable: "TableOfContents",
                        principalColumn: "tocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCollections_CollectionsCollectionId",
                table: "BookCollections",
                column: "CollectionsCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPages_BookId",
                table: "BookPages",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookpreviews_BookId",
                table: "Bookpreviews",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdAuthor",
                table: "Books",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdBookType",
                table: "Books",
                column: "IdBookType");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdGenre",
                table: "Books",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterNames_TocId",
                table: "ChapterNames",
                column: "TocId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TableOfContents_BookId",
                table: "TableOfContents",
                column: "BookId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCollections");

            migrationBuilder.DropTable(
                name: "BookPages");

            migrationBuilder.DropTable(
                name: "Bookpreviews");

            migrationBuilder.DropTable(
                name: "ChapterNames");

            migrationBuilder.DropTable(
                name: "ListenAudioBookPages");

            migrationBuilder.DropTable(
                name: "ReadOnlineBooks");

            migrationBuilder.DropTable(
                name: "Colections");

            migrationBuilder.DropTable(
                name: "TableOfContents");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
