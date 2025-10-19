using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;
using Wishio.Contract.Dto.Wish;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishController(IWishService wishService) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<ResponseDto<WishResponseDto>>> Get(Guid id, CancellationToken ct = default)
  {
    try
    {
      var wishlist = await wishService.Get(id, ct);
      return Ok(ResponseDto<WishResponseDto>.Success(wishlist));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }

  [HttpGet("by-wishlist")]
  public async Task<ActionResult<ResponseDto<List<WishResponseDto>>>> GetByWithlistId(Guid wishlistId, CancellationToken ct = default)
  {
    try
    {
      var wishlists = await wishService.GetByWishlistId(wishlistId, ct);
      return Ok(ResponseDto<WishResponseDto>.SuccessList(wishlists));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }

  [HttpPost]
  public async Task<ActionResult<ResponseDto<WishResponseDto>>> Create([FromBody] WishCreateRequestDto wish, CancellationToken ct = default)
  {
    try
    {
      var created = await wishService.Create(wish, ct);
      return Ok(ResponseDto<WishResponseDto>.Success(created));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }

  [HttpPut]
  public async Task<ActionResult<ResponseDto<WishResponseDto>>> Update([FromBody] WishUpdateRequestDto wish, CancellationToken ct = default)
  {
    try
    {
      var updated = await wishService.Update(wish, ct);
      return Ok(ResponseDto<WishResponseDto>.Success(updated));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }
}