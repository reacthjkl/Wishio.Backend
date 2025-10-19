using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Wish;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Business.Services;

public class WishService(IWishRepository wishRepository, IMapper mapper) : IWishService
{
  public async Task<WishResponseDto> Get(Guid id)
  {
    var wish = await wishRepository.Get(id)
      ?? throw new KeyNotFoundException("Wish not found");

    return mapper.Map<WishResponseDto>(wish);
  }

  public async Task<List<WishResponseDto>> GetByWishlistId(Guid wishlistId)
  {
    var wish = await wishRepository.GetByWishlistId(wishlistId);

    return mapper.Map<List<WishResponseDto>>(wish);
  }

  public async Task<WishResponseDto> Create(WishCreateRequestDto wish)
  {
    var entity = mapper.Map<Wish>(wish);

    var created = await wishRepository.Create(entity);

    return mapper.Map<WishResponseDto>(created);
  }

  public async Task<WishResponseDto> Update(WishUpdateRequestDto wish)
  {
    var entity = await wishRepository.Get(wish.Id)
      ?? throw new KeyNotFoundException("Wish not found");

    mapper.Map(wish, entity);

    var updated = await wishRepository.Update(entity);

    return mapper.Map<WishResponseDto>(updated);
  }
}