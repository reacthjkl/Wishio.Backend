using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistence.Entities;
using Wishio.Persistence.Interfaces;

namespace Wishio.Business.Services;

public class WishlistService(IWishlistRepository wishlistRepository, IMapper mapper) : IWishlistService
{
  public async Task<WishlistResponseDto> Get(Guid id, CancellationToken ct = default)
  {
    Wishlist entity = await wishlistRepository.Get(id, ct)
       ?? throw new KeyNotFoundException("Wishlist not found");

    return mapper.Map<WishlistResponseDto>(entity);
  }

  public async Task<WishlistResponseDto> Create(WishlistRequestDto wishlist, CancellationToken ct = default)
  {
    var entity = mapper.Map<Wishlist>(wishlist);

    var created = await wishlistRepository.Create(entity, ct);

    return mapper.Map<WishlistResponseDto>(created);
  }
}