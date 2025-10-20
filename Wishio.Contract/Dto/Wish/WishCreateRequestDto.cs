using System.ComponentModel.DataAnnotations;

namespace Wishio.Contract.Dto.Wish;

public class WishCreateRequestDto
{
    [Required] [MaxLength(255)] public string Name { get; set; } = null!;

    [MaxLength(2000)] public string? Description { get; set; }

    [MaxLength(2000)] public string? Link { get; set; }

    [Required] public Guid WishlistId { get; set; }

    public Guid? PictureId { get; set; }
}