using KetabBaz.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KetabBaz.Infrastructure.Data;

public class KetabBazDbContext : IdentityDbContext<User>
{
    public KetabBazDbContext(DbContextOptions<KetabBazDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<View> Views { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Carousel> Carousels { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Slideshow> Slideshows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KetabBazDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
