using Wishio.Persistance.Entities;

namespace Wishio.Persistance.Interfaces;

public interface IWishRepository
{
  Task<Wish?> Get(Guid id, CancellationToken ct = default);
  Task<List<Wish>> GetByWishlistId(Guid wishlistId, CancellationToken ct = default);
  Task<Wish> Create(Wish wish, CancellationToken ct = default);
  Task<Wish> Update(Wish wish, CancellationToken ct = default);
}