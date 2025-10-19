using Wishio.Contract.Dto;
using Microsoft.AspNetCore.Http;

namespace Wishio.Business.Interfaces;

public interface IPictureService
{
  Task<PictureResponseDto> Get(Guid id, CancellationToken ct = default);
  Task<PictureResponseDto> Create(IFormFile file, CancellationToken ct = default);
}