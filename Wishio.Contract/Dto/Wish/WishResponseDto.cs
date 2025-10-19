using System.ComponentModel.DataAnnotations;

namespace Wishio.Contract.Dto.Wish;

public class WishResponseDto
{
  [Required]
  public Guid Id { get; set; }

  [Required]
  [MaxLength(255)]
  public string Name { get; set; } = null!;

  [MaxLength(2000)]
  public string? Description { get; set; }

  [MaxLength(2000)]
  public string? Link { get; set; }

  [Required]
  public bool IsReserved { get; set; }

  [Required]
  public string WishlistId { get; set; } = null!;

  public Guid? PictureId { get; set; }
}