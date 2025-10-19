using Microsoft.EntityFrameworkCore;
using Wishio.Persistance.Entities;

namespace Wishio.Persistance;

public class WishioContext : DbContext
{
  public virtual DbSet<Wishlist> Wishlists { get; set; }

  public string DbPath { get; }

  public WishioContext()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = Path.Join(path, "wishio.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Wishlist>(entity =>
        {
          entity.HasKey(e => e.Id);

          entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        });
  }

}
