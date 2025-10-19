using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController(IPictureService pictureService) : ControllerBase
{
  [HttpGet("{id:guid}")]
  public async Task<IActionResult> Get(Guid id, CancellationToken ct = default)
  {
    try
    {
      var picture = await pictureService.Get(id, ct);

      return File(picture.BinaryData, picture.ContentType, picture.FileName);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromForm] IFormFile file, CancellationToken ct = default)
  {
    try
    {

      var result = await pictureService.Create(file, ct);
      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
