using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;
using Wishio.Contract.Dto.Wishlist;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishlistController(IWishlistService wishlistService) : ControllerBase
{
  [HttpGet("{id:guid}")]
  public async Task<ActionResult<ResponseDto<WishlistResponseDto>>> Get(Guid id, CancellationToken ct = default)
  {
    try
    {
      var wishlist = await wishlistService.Get(id, ct);
      return Ok(ResponseDto<WishlistResponseDto>.Success(wishlist));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }

  [HttpPost]
  public async Task<ActionResult<ResponseDto<WishlistResponseDto>>> Create([FromBody] WishlistRequestDto wishlist, CancellationToken ct = default)
  {
    try
    {
      var created = await wishlistService.Create(wishlist, ct);
      return Ok(ResponseDto<WishlistResponseDto>.Success(created));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }
}