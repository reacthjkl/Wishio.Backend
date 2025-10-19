using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Business.Services;

public class WishlistService(IWishlistRepository wishlistRepository, IMapper mapper) : IWishlistService
{
  public async Task<WishlistResponseDto> Get(Guid id)
  {
    Wishlist entity = await wishlistRepository.Get(id)
       ?? throw new KeyNotFoundException("Wishlist not found");

    return mapper.Map<WishlistResponseDto>(entity);
  }

  public async Task<WishlistResponseDto> Create(WishlistRequestDto wishlist)
  {
    var entity = mapper.Map<Wishlist>(wishlist);

    var created = await wishlistRepository.Create(entity);

    return mapper.Map<WishlistResponseDto>(created);
  }
}