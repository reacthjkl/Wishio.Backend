using Wishio.Contract.Dto.Picture;

namespace Wishio.Business.Interfaces;

public interface IPictureService
{
    Task<PictureResponseDto> Get(Guid id, CancellationToken ct = default);
    Task<PictureResponseDto> Create(PictureRequestDto picture, CancellationToken ct = default);
}