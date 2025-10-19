using Wishio.Contract.Dto.Wishlist;

namespace Wishio.Business.Interfaces;

public interface IWishlistService
{
  public Task<WishlistResponseDto> GetByIdAsync(Guid id);
}