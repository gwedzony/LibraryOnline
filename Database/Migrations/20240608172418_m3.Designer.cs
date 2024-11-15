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
    [Migration("20240608172418_m3")]
    partial class m3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int?>("BookNewsCardId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdAuthor")
                        .HasColumnType("int");

                    b.Property<int>("IdBookType")
                        .HasColumnType("int");

                    b.Property<int>("IdGenre")
                        .HasColumnType("int");

                    b.Property<long?>("ReadCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image")
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

            modelBuilder.Entity("Database.DATA.CMS.BookNewsCard", b =>
                {
                    b.Property<int>("BookNewsCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookNewsCardId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookLink")
                        .HasColumnType("longtext");

                    b.Property<string>("SmallCoverImg")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("WhenCreated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("BookNewsCardId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookNewsCards");
                });

            modelBuilder.Entity("Database.DATA.CMS.BookRandomCollections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("RandomCollections");
                });

            modelBuilder.Entity("Database.DATA.Library.AuthorPage", b =>
                {
                    b.Property<int>("AuthorPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AuthorPageId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("AuthorPageId");

                    b.HasIndex("AuthorId");

                    b.ToTable("AuthorPages");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.Property<int>("BookPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BookPageId"));

                    b.Property<string>("AudioUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("BigCoverImg")
                        .HasColumnType("longtext");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("longtext");

                    b.HasKey("BookPageId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookPages");
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

            modelBuilder.Entity("Database.Data.BookScheme.BookCollection", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CollectionId");

                    b.HasIndex("CollectionId");

                    b.ToTable("BookCollections");
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

            modelBuilder.Entity("Database.DATA.CMS.BookNewsCard", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookNewsCard")
                        .HasForeignKey("Database.DATA.CMS.BookNewsCard", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.DATA.Library.AuthorPage", b =>
                {
                    b.HasOne("Database.Data.BookScheme.Author", "Author")
                        .WithMany("AuthorPages")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Database.DATA.Library.BookPage", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithOne("BookPage")
                        .HasForeignKey("Database.DATA.Library.BookPage", "BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Database.Data.BookScheme.BookCollection", b =>
                {
                    b.HasOne("Database.DATA.BookScheme.Book", "Book")
                        .WithMany("BookCollections")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.DATA.BookScheme.Collections", "Collections")
                        .WithMany("BookCollections")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Collections");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Book", b =>
                {
                    b.Navigation("BookCollections");

                    b.Navigation("BookNewsCard");

                    b.Navigation("BookPage");
                });

            modelBuilder.Entity("Database.DATA.BookScheme.Collections", b =>
                {
                    b.Navigation("BookCollections");
                });

            modelBuilder.Entity("Database.Data.BookScheme.Author", b =>
                {
                    b.Navigation("AuthorPages");

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
