namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Wishio.Business.Helpers;
using Wishio.Contract.Dto;
using Wishio.Persistance.Entities;

public class PictureProfile : Profile
{
    public PictureProfile()
    {
        CreateMap<Picture, PictureResponseDto>();

        CreateMap<IFormFile, Picture>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(dest => dest.BinaryData, opt => opt.MapFrom(src => BinaryHelper.GetBinaryData(src)));
    }
}