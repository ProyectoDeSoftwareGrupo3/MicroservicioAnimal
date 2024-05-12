using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class FotoMapper : IFotoMapper
    {
        public Task<CreateFotoResponse> CreateFotoResponse(Foto foto)
        {
            var response = new CreateFotoResponse
            {
                Id = foto.Id,
                url = foto.url,
            };
            return Task.FromResult(response);
        }

        public Task<List<CreateFotoResponse>> CreateListFotoResponse(List<Foto> fotos)
        {
            List<CreateFotoResponse> fotoResponses = new List<CreateFotoResponse>();
            if (fotos == null)
            {
                return Task.FromResult(fotoResponses);
            }
            foreach (var foto in fotos)
            {
                fotoResponses.Add(new CreateFotoResponse
                {
                    Id = foto.Id,
                    url = foto.url,
                });
            }
            
            return Task.FromResult(fotoResponses);
        }

        public Task<GetFotoReponse> GetFotoResponse(Foto foto)
        {
            var response = new GetFotoReponse
            {
                url = foto.url,
            };
            return Task.FromResult(response);
        }
    }
}
