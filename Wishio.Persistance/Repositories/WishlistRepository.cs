using Microsoft.EntityFrameworkCore;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Persistance.Repositories;

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