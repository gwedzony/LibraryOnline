using Database.Data.BookScheme;
using Database.DATA.CMS;
using Database.DATA.Library;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class DatabaseContext : DbContext
{
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors {  get; set; }
    public DbSet<Genre> Genres { get; set; }

    public DbSet<BookPreview> Bookpreviews { get; set; }
    public DbSet<BookPage> BookPages { get; set; }
    public DbSet<ListenAudioBookPage> ListenAudioBookPages { get; set; }
    public DbSet<ReadOnlineBook> ReadOnlineBooks { get; set; }
    public DbSet<BookType> BookTypes {  get; set; }
    
    public DbSet<Collections> Colections {  get; set; }
    
    
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=identifier.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
