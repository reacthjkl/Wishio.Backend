using Microsoft.AspNetCore.Http;

namespace Wishio.Business.Helpers;

public class BinaryHelper
{
  public static byte[] GetBinaryData(IFormFile file)
  {
    using var memoryStream = new MemoryStream();
    file.CopyTo(memoryStream);
    return memoryStream.ToArray();
  }
}