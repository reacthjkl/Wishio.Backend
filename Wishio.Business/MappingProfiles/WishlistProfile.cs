using AutoMapper;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistence.Entities;

namespace Wishio.Business.MappingProfiles;

public class WishlistProfile : Profile
{
    public WishlistProfile()
    {
        CreateMap<Wishlist, WishlistResponseDto>();
        CreateMap<WishlistRequestDto, Wishlist>();
    }
}