using Microsoft.EntityFrameworkCore;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Persistance.Repositories;

public class WishlistRepository(WishioContext context) : IWishlistRepository
{
  public async Task<Wishlist?> GetByIdAsync(Guid id)
  {
    return await context.Wishlists.FirstOrDefaultAsync(w => w.Id == id);
  }
}