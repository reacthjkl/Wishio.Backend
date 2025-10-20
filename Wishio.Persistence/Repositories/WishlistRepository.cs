using Microsoft.EntityFrameworkCore;
using Wishio.Persistence.Entities;
using Wishio.Persistence.Interfaces;

namespace Wishio.Persistence.Repositories;

public class WishlistRepository(WishioContext context) : IWishlistRepository
{
  public async Task<Wishlist?> Get(Guid id, CancellationToken ct = default)
  {
    return await context.Wishlists.FirstOrDefaultAsync(w => w.Id == id, ct);
  }

  public async Task<Wishlist> Create(Wishlist wishlist, CancellationToken ct = default)
  {
    context.Wishlists.Add(wishlist);
    await context.SaveChangesAsync(ct);
    return wishlist;
  }
}