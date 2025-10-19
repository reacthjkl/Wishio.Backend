namespace Wishio.Persistance.Entities;

public class Picture
{
  public Guid Id { get; set; }
  public byte[] BinaryData { get; set; } = [];

  // Optional metadata
  public string? FileName { get; set; }
  public string? ContentType { get; set; }
  public long FileSize { get; set; }
}