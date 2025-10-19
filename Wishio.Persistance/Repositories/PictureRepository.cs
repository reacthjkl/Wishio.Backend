using Microsoft.EntityFrameworkCore;
using Wishio.Persistance.Entities;
using Wishio.Persistance.Interfaces;

namespace Wishio.Persistance.Repositories;

public class PictureRepository(WishioContext context) : IPictureRepository
{
  public async Task<Picture?> Get(Guid id, CancellationToken ct = default)
  {
    return await context.Pictures.FirstOrDefaultAsync(p => p.Id == id, ct);
  }

  public async Task<Picture> Create(Picture picture, CancellationToken ct = default)
  {
    context.Pictures.Add(picture);
    await context.SaveChangesAsync(ct);
    return picture;
  }
}