using Wishio.Persistance.Entities;

namespace Wishio.Persistance.Interfaces;

public interface IPictureRepository
{
  Task<Picture?> Get(Guid id, CancellationToken ct = default);
  Task<Picture> Create(Picture picture, CancellationToken ct = default);
}