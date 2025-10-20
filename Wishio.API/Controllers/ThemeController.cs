using Microsoft.AspNetCore.Mvc;
using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;

namespace Wishio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThemeController(IThemeService themeService) : ControllerBase
{
    [HttpGet]
    public ActionResult<ResponseDto<ThemeResponseDto>> Get()
    {
        try
        {
            var themes = themeService.Get();
            return Ok(themes);
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseDto<EmptyDto>.Fail(ex.Message));
        }
    }
}