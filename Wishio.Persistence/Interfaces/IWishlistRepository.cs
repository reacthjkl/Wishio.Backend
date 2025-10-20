using Wishio.Persistence.Entities;

namespace Wishio.Persistence.Interfaces;

public interface IWishlistRepository
{
    public Task<Wishlist?> Get(Guid id, CancellationToken ct = default);
    public Task<Wishlist> Create(Wishlist wishlist, CancellationToken ct = default);
}