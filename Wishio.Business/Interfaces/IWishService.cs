using Wishio.Contract.Dto.Wish;

namespace Wishio.Business.Interfaces;

public interface IWishService
{
    Task<WishResponseDto> Get(Guid id, CancellationToken ct = default);
    Task<List<WishResponseDto>> GetByWishlistId(Guid wishlistId, CancellationToken ct = default);
    Task<WishResponseDto> Create(WishCreateRequestDto wish, CancellationToken ct = default);
    Task<WishResponseDto> Update(Guid id, WishUpdateRequestDto wish, CancellationToken ct = default);
}