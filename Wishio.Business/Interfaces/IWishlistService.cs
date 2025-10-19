using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistance.Entities;

namespace Wishio.Business.Interfaces;

public interface IWishlistService
{
  Task<WishlistResponseDto> Get(Guid id);
  Task<WishlistResponseDto> Create(WishlistRequestDto wishlist);
}