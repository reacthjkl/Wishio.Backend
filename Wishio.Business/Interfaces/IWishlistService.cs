using Wishio.Contract.Dto;

namespace Wishio.Business.Interfaces;

public interface IWishlistService
{
  public Task<WishlistDto> GetByIdAsync(Guid id);
}