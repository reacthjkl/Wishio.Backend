using Wishio.Persistence.Entities;

namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto.Wish;

public class WishProfile : Profile
{
    public WishProfile()
    {
        CreateMap<Wish, WishResponseDto>();
        CreateMap<WishCreateRequestDto, Wish>();
        CreateMap<WishUpdateRequestDto, Wish>();
    }
}