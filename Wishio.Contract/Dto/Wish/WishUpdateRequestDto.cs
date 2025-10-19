using System.ComponentModel.DataAnnotations;

namespace Wishio.Contract.Dto.Wish;

public class WishUpdateRequestDto
{
  [Required]
  public Guid Id { get; set; }

  [Required]
  public bool IsReserved { get; set; }
}