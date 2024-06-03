using Database.Data.BookScheme;
using Database.DATA.BookScheme;
using Database.DATA.CMS;
using Database.DATA.Library;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class DatabaseContext : DbContext
{
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Genre> Genres { get; set; }

    public DbSet<BookPreviewCollection> BookPreviewCollections { get; set; }
    public DbSet<BookPreviewNewest> BookPreviewNewests { get; set; }
    public DbSet<BookPage> BookPages { get; set; }
    public DbSet<ListenAudioBookPage> ListenAudioBookPages { get; set; }
    public DbSet<ReadOnlineBook> ReadOnlineBooks { get; set; }
    public DbSet<BookType> BookTypes {  get; set; }
    public DbSet<Collections> Collections {  get; set; }
    
    
    
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
        
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
