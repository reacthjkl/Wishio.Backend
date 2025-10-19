using Wishio.Contract.Dto.Wish;

namespace Wishio.Business.Interfaces;

public interface IWishService
{
  Task<WishResponseDto> Get(Guid id);
  Task<List<WishResponseDto>> GetByWishlistId(Guid wishlistId);
  Task<WishResponseDto> Create(WishCreateRequestDto wish);
  Task<WishResponseDto> Update(WishUpdateRequestDto wish);
}