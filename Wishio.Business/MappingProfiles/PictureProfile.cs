namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Wishio.Contract.Dto;
using Wishio.Contract.Dto.Wishlist;
using Wishio.Persistance.Entities;

public class PictureProfile : Profile
{
    public PictureProfile()
    {
        CreateMap<Picture, PictureDto>().ReverseMap();
    }
}