using Wishio.Contract.Dto.Wishlist;

namespace Wishio.Business.Interfaces;

public interface IWishlistService
{
    Task<WishlistResponseDto> Get(Guid id, CancellationToken ct = default);
    Task<WishlistResponseDto> Create(WishlistRequestDto wishlist, CancellationToken ct = default);
}