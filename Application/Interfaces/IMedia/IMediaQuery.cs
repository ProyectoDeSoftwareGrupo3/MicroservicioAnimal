using Domain.Entities;

namespace Application.Interfaces;

public interface IMediaQuery
{
    Task<List<Media>> GetListMedia();
    Task<Media> GetMediaById(int id);
}
