using System.ComponentModel.DataAnnotations;
using Wishio.Contract.Enums;

namespace Wishio.Contract.Dto.Wishlist;

public class WishlistRequestDto
{
  [Required]
  [MaxLength(255)]
  public string Name { get; set; } = null!;

  [MaxLength(2000)]
  public string? Description { get; set; }

  public Guid? PictureId { get; set; }

  [Required]
  public Theme Theme { get; set; }

  public Guid? CustomThemePictureId { get; set; }
}