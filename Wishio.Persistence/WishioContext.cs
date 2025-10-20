using Microsoft.EntityFrameworkCore;
using Wishio.Persistence.Entities;

namespace Wishio.Persistence;

public class WishioContext : DbContext
{
    public WishioContext(DbContextOptions<WishioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Wishlist> Wishlists { get; set; }
    public virtual DbSet<Wish> Wishes { get; set; }
    public virtual DbSet<Picture> Pictures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id);

            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(2000);

            entity.HasMany(e => e.Wishes)
                .WithOne(e => e.Wishlist)
                .HasForeignKey(e => e.WishlistId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Wish>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id);

            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Link).HasMaxLength(2000);
            entity.Property(e => e.IsReserved).HasDefaultValue(false);
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id);

            entity.Property(e => e.BinaryData)
                .IsRequired();

            entity.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.FileSize)
                .IsRequired();
        });
    }
}