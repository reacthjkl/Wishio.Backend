using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Wish;
using Wishio.Persistence.Entities;
using Wishio.Persistence.Interfaces;

namespace Wishio.Business.Services;

public class WishService(IWishRepository wishRepository, IMapper mapper) : IWishService
{
    public async Task<WishResponseDto> Get(Guid id, CancellationToken ct = default)
    {
        var wish = await wishRepository.Get(id, ct)
                   ?? throw new KeyNotFoundException("Wish not found");

        return mapper.Map<WishResponseDto>(wish);
    }

    public async Task<List<WishResponseDto>> GetByWishlistId(Guid wishlistId, CancellationToken ct = default)
    {
        var wish = await wishRepository.GetByWishlistId(wishlistId, ct);

        return mapper.Map<List<WishResponseDto>>(wish);
    }

    public async Task<WishResponseDto> Create(WishCreateRequestDto wish, CancellationToken ct = default)
    {
        var entity = mapper.Map<Wish>(wish);

        var created = await wishRepository.Create(entity, ct);

        return mapper.Map<WishResponseDto>(created);
    }

    public async Task Reserve(Guid id, CancellationToken ct = default)
    {
        var wish = await wishRepository.Get(id, ct)
                   ?? throw new KeyNotFoundException("Wish not found");

        if (wish.IsReserved) throw new InvalidOperationException("Wish already reserved");

        wish.IsReserved = true;

        var updated = await wishRepository.Update(wish, ct);
    }
}