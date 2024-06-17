using Database.Data.BookScheme;
using Database.DATA.BookScheme;
using Database.DATA.CMS;
using Database.DATA.Library;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class DatabaseContext : DbContext
{
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookCollection> BookCollections { get; set; }
    public DbSet<BookType> BookTypes { get; set; }
    public DbSet<Collections> Collections { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookNewsCard> BookNewsCards { get; set; }
    public DbSet<BookPage> BookPages { get; set; }
    public DbSet<AuthorPage> AuthorPages { get; set; }
    public DbSet<BookRandomCollections> RandomCollections { get; set; }
    
 
    
    
    
    public DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(Constant.ConnectionString,ServerVersion.AutoDetect(Constant.ConnectionString));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Book>()
            .HasOne(a => a.Author)
            .WithMany(b => b.Books);
        modelBuilder.Entity<Book>()
            .HasOne(bt => bt.BookType)
            .WithMany(bt => bt.Book);
        modelBuilder.Entity<Book>()
            .HasOne(bg => bg.Genre)
            .WithMany(bg => bg.Book);
        
        modelBuilder.Entity<Book>()
            .HasOne(bnc => bnc.BookNewsCard)
            .WithOne(bnc => bnc.Book)
            .HasForeignKey<BookNewsCard>(b => b.BookId);

        modelBuilder.Entity<BookCollection>().HasKey(bc => new { bc.BookId, bc.CollectionId });
        
        modelBuilder.Entity<BookCollection>()
            .HasOne(bc => bc.Book)
            .WithMany(b => b.BookCollections)
            .HasForeignKey(bc => bc.BookId);

        // Konfiguracja relacji Collection -> BookCollection
        modelBuilder.Entity<BookCollection>()
            .HasOne(bc => bc.Collections)
            .WithMany(c => c.BookCollections)
            .HasForeignKey(bc => bc.CollectionId);

    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
