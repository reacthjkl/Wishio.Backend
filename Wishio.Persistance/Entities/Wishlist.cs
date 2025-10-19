using Wishio.Contract.Enums;

namespace Wishio.Persistance.Entities;

public class Wishlist
{
  // Basic Info
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = null!;
  public string? Description { get; set; }

  // Picture
  public Guid? PictureId { get; set; }
  public Picture? Picture { get; set; }

  // Theme
  public Theme Theme { get; set; }
  public Guid? CustomThemePictureId { get; set; }
  public Picture? CustomThemePicture { get; set; }

  public virtual ICollection<Wish> Wishes { get; set; } = [];
}