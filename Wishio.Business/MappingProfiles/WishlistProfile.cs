namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto;
using Wishio.Persistance.Entities;

public class WishlistProfile : Profile
{
    public WishlistProfile()
    {
        CreateMap<Wishlist, WishlistDto>().ReverseMap();
    }
}