using Wishio.Business.Interfaces;
using Wishio.Contract.Dto;
using Wishio.Contract.Enums;

namespace Wishio.Business.Services;

public class ThemeService : IThemeService
{
    public List<ThemeResponseDto> Get()
    {
        return Enum.GetValues<Theme>()
            .Select(t => new ThemeResponseDto { Id = (int)t, Name = t.ToString() }).ToList();
    }
}