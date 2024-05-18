using Application.Request;
using Application.Response;

namespace Application.Interfaces;

public interface IMediaServices
{
    Task<CreateMediaResponse> CreateMedia(CreateMediaRequest request);
    Task<GetMediaReponse> UpdateMedia(UpdateMediaRequest request);
    Task<CreateMediaResponse> DeleteMedia(DeleteMediaRequest request);
    Task<List<GetMediaReponse>> GetListMedia();
    Task<GetMediaReponse> GetMediaById(int id);
}
