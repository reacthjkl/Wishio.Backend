namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto.Wish;
using Wishio.Persistance.Entities;

public class WishProfile : Profile
{
    public WishProfile()
    {
        CreateMap<Wishlist, WishResponseDto>();
        CreateMap<WishRequestDto, Wishlist>();
    }
}