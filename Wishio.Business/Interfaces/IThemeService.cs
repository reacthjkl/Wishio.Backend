using Wishio.Contract.Dto;

namespace Wishio.Business.Interfaces;

public interface IThemeService
{
    List<ThemeResponseDto> Get();
}