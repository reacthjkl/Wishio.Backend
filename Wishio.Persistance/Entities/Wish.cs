namespace Wishio.Persistance.Entities;

public class Wish
{
  // Basic Info
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
  public string? Link { get; set; }
  public bool IsReserved { get; set; }

  // Picture
  public Guid? PictureId { get; set; }
  public Picture? Picture { get; set; } = null!;

  // Connection to a Wishlist entity
  public Guid WishlistId { get; set; }
  public Wishlist Wishlist { get; set; } = null!;
}