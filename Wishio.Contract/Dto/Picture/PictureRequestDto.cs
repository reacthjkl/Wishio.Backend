using Microsoft.AspNetCore.Http;

namespace Wishio.Contract.Dto.Picture;

public class PictureRequestDto
{
    public IFormFile File { get; set; } = null!;
}