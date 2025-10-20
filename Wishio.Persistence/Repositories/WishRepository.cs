using Microsoft.EntityFrameworkCore;
using Wishio.Persistence.Entities;
using Wishio.Persistence.Interfaces;

namespace Wishio.Persistence.Repositories;

public class WishRepository(WishioContext context) : IWishRepository
{
  public async Task<Wish?> Get(Guid id, CancellationToken ct = default)
  {
    return await context.Wishes.FirstOrDefaultAsync(w => w.Id == id, ct);
  }

  public async Task<List<Wish>> GetByWishlistId(Guid wishlistId, CancellationToken ct = default)
  {
    return await context.Wishes.Where(w => w.WishlistId == wishlistId).ToListAsync(ct);
  }

  public async Task<Wish> Create(Wish wish, CancellationToken ct = default)
  {
    context.Wishes.Add(wish);
    await context.SaveChangesAsync(ct);
    return wish;
  }

  public async Task<Wish> Update(Wish wish, CancellationToken ct = default)
  {
    context.Wishes.Update(wish);
    await context.SaveChangesAsync(ct);
    return wish;
  }
}