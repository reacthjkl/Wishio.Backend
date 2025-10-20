using Wishio.Persistence.Entities;

namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto.Wishlist;

public class WishlistProfile : Profile
{
    public WishlistProfile()
    {
        CreateMap<Wishlist, WishlistResponseDto>();
        CreateMap<WishlistRequestDto, Wishlist>();
    }
}