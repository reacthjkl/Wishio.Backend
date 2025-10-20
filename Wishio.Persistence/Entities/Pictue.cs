namespace Wishio.Persistence.Entities;

public class Picture
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public byte[] BinaryData { get; set; } = [];

  public string FileName { get; set; } = null!;
  public string ContentType { get; set; } = null!;
  public long FileSize { get; set; }
}