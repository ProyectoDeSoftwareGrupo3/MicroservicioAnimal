using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class MediaMapper : IMediaMapper
    {
        public Task<CreateMediaResponse> CreateMediaResponse(Media media)
        {
            var response = new CreateMediaResponse
            {
                Id = media.Id,
                url = media.url,
            };
            return Task.FromResult(response);
        }

        public Task<List<GetMediaReponse>> CreateListMediaResponse(List<Media> medias)
        {
            List<GetMediaReponse> mediaResponses = new List<GetMediaReponse>();
            if (medias == null)
            {
                return Task.FromResult(mediaResponses);
            }
            foreach (var foto in medias)
            {
                mediaResponses.Add(new GetMediaReponse
                {
                    url = foto.url,
                });
            }
            
            return Task.FromResult(mediaResponses);
        }

        public Task<GetMediaReponse> GetMediaResponse(Media media)
        {
            var response = new GetMediaReponse
            {
                url = media.url,
            };
            return Task.FromResult(response);
        }
    }
}
