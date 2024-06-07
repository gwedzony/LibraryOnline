﻿// <auto-generated />
using System;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240604154831_m2")]
    partial class m2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BookCollections", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionsCollectionId")
                        .HasColumnType("int");

                    b.HasKey("BooksBookId", "CollectionsCollectionId");

                    b.HasIndex("CollectionsCollectionId");

                    b.ToTable("BookCollections");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookId"));

                    b.Property<DateTime>("AddDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdBookType")
                        .HasColumnType("int");

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

                    b.Property<long>("ReadCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BookId");

                    b.HasIndex("IdAuthor");

                    b.HasIndex("IdBookType");

                    b.HasIndex("IdGenre");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Collections", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CollectionId"));

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CollectionId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewCollection", b =>
                {
                    b.Property<int>("PreviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PreviewId"));

                    b.Property<string>("AudioUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("SmallCoverImg")
                        .HasColumnType("longtext");

                    b.HasKey("PreviewId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookPreviewCollections");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewNewest", b =>
                {
                    b.Property<int>("NewestBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("NewestBookId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookLink")
                        .HasColumnType("longtext");

                    b.Property<string>("SmallCoverImg")
                        .HasColumnType("longtext");

                    b.HasKey("NewestBookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookPreviewNewests");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.Property<int>("BookPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookPageId"));

                    b.Property<string>("BigCoverImg")
                        .HasColumnType("longtext");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("longtext");

                    b.HasKey("BookPageId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookPages");
                });

            modelBuilder.Entity("Database.DATA.Library.ListenAudioBookPage", b =>
                {
                    b.Property<int>("AudioPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AudioPageId"));

                    b.Property<string>("AudioUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.HasKey("AudioPageId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("ListenAudioBookPages");
                });

            modelBuilder.Entity("Database.DATA.Library.ReadOnlineBook", b =>
                {
                    b.Property<int>("ReadOnlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ReadOnlineId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.HasKey("ReadOnlineId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("ReadOnlineBooks");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Database.Data.BookScheme.BookType", b =>
                {
                    b.Property<int>("BookTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookTypeId"));

                    b.Property<string>("BookTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BookTypeId");

                    b.ToTable("BookTypes");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookCollections", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DATA.BookScheme.Collections", null)
                        .WithMany()
                        .HasForeignKey("CollectionsCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.HasOne("Database.Data.BookScheme.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookScheme.BookType", "BookType")
                        .WithMany("Book")
                        .HasForeignKey("IdBookType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Data.BookScheme.Genre", "Genre")
                        .WithMany("Book")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("BookType");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewCollection", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookPreview")
                        .HasForeignKey("Database.DATA.CMS.BookPreviewCollection", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookPreviewNewest", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookPage")
                        .HasForeignKey("Database.DATA.Library.BookPage", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.ListenAudioBookPage", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("ListenAudioBookPage")
                        .HasForeignKey("Database.DATA.Library.ListenAudioBookPage", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.ReadOnlineBook", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("ReadOnlineBook")
                        .HasForeignKey("Database.DATA.Library.ReadOnlineBook", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Navigation("BookPage");

                    b.Navigation("BookPreview");

                    b.Navigation("ListenAudioBookPage");

                    b.Navigation("ReadOnlineBook");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Database.Data.BookScheme.BookType", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Genre", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}