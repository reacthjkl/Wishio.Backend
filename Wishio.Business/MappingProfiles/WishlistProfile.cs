namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistance.Entities;

public class WishlistProfile : Profile
{
    public WishlistProfile()
    {
        CreateMap<Wishlist, WishlistResponseDto>();
        CreateMap<WishlistRequestDto, Wishlist>();
    }
}