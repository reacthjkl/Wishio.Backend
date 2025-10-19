namespace Wishio.Contract.Dto;

public class PictureDto
{
  public Guid Id { get; set; }
  public byte[] BinaryData { get; set; } = [];

  public string FileName { get; set; } = null!;
  public string ContentType { get; set; } = null!;
  public long FileSize { get; set; }
}