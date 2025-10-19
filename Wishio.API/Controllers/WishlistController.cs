using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishlistController(IWishlistService wishlistService) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<ResponseDto<WishlistDto>>> GetWishList(Guid id)
  {
    try
    {
      var wishlist = await wishlistService.GetByIdAsync(id);
      return Ok(ResponseDto<WishlistDto>.Success(wishlist));
    }
    catch (Exception e)
    {
      return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
    }
  }
}