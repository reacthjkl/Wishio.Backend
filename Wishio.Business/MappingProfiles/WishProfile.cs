using AutoMapper;
using Wishio.Contract.Dto.Wish;
using Wishio.Persistence.Entities;

namespace Wishio.Business.MappingProfiles;

public class WishProfile : Profile
{
    public WishProfile()
    {
        CreateMap<Wish, WishResponseDto>();
        CreateMap<WishCreateRequestDto, Wish>();
        CreateMap<WishUpdateRequestDto, Wish>();
    }
}