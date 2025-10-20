using Wishio.Persistence.Entities;

namespace Wishio.Business.MappingProfiles;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Wishio.Business.Helpers;
using Wishio.Contract.Dto;
using Wishio.Contract.Dto.Picture;

public class PictureProfile : Profile
{
    public PictureProfile()
    {
        CreateMap<Picture, PictureResponseDto>();

        CreateMap<PictureRequestDto, Picture>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.File.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.File.ContentType))
            .ForMember(dest => dest.FileSize, opt => opt.MapFrom(src => src.File.Length))
            .ForMember(dest => dest.BinaryData, opt => opt.MapFrom(src => BinaryHelper.GetBinaryData(src.File)));
    }
}