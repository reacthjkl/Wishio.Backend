using Wishio.Persistance.Entities;

namespace Wishio.Persistance.Interfaces;

public interface IWishlistRepository
{
  public Task<Wishlist?> GetByIdAsync(Guid id);
}