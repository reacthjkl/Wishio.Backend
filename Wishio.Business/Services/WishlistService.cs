using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Business.Services;

public class WishlistService(IWishlistRepository wishlistRepository, IMapper mapper) : IWishlistService
{
  public async Task<WishlistResponseDto> GetByIdAsync(Guid id)
  {
    Wishlist entity = await wishlistRepository.GetByIdAsync(id)
       ?? throw new KeyNotFoundException("Wishlist not found");

    return mapper.Map<WishlistResponseDto>(entity);
  }
}