using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;
using Wishio.Contract.Dto.Wish;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishController(IWishService wishService) : ControllerBase
{
    [HttpGet("{id:guid}")]
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

    [HttpGet("by-wishlist/{wishlistId:guid}")]
    public async Task<ActionResult<ResponseDto<List<WishResponseDto>>>> GetByWishlistId(Guid wishlistId,
        CancellationToken ct = default)
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
    public async Task<ActionResult<ResponseDto<WishResponseDto>>> Create([FromBody] WishCreateRequestDto wish,
        CancellationToken ct = default)
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

    [HttpPut("reserve/{id:guid}")]
    public async Task<ActionResult<ResponseDto<WishResponseDto>>> Reserve(Guid id, CancellationToken ct = default)
    {
        try
        {
            await wishService.Reserve(id, ct);
            return Ok(ResponseDto<EmptyDto>.Success());
        }
        catch (Exception e)
        {
            return BadRequest(ResponseDto<EmptyDto>.Fail(e.Message));
        }
    }
}