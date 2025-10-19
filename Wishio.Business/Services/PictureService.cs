using AutoMapper;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto.Picture;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Business.Services;

public class PictureService(IPictureRepository pictureRepository, IMapper mapper) : IPictureService
{
  public async Task<PictureResponseDto> Get(Guid id, CancellationToken ct = default)
  {
    var picture = await pictureRepository.Get(id, ct)
      ?? throw new KeyNotFoundException($"Picture not found");

    return mapper.Map<PictureResponseDto>(picture);
  }

  public async Task<PictureResponseDto> Create(PictureRequestDto picture, CancellationToken ct = default)
  {
    var entity = mapper.Map<Picture>(picture);

    var created = await pictureRepository.Create(entity, ct);

    return mapper.Map<PictureResponseDto>(created);
  }
}