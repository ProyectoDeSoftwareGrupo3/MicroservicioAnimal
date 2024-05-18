using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IMediaMapper
    {
        Task<List<GetMediaReponse>> CreateListMediaResponse(List<Media> fotos);
        Task<GetMediaReponse> GetMediaResponse(Media foto);
        Task<CreateMediaResponse> CreateMediaResponse(Media foto);
    }
}
