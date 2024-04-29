using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class AnimalTipoMapper : IAnimalTipoMapper
    {

        public Task<CreateAnimalTipoResponse> CreateAnimalTipoResponse(AnimalTipo tipo)
        {
            var result = new CreateAnimalTipoResponse
            {
                id = tipo.Id,
                Descripcion = tipo.Descripcion,   
            };

            return Task.FromResult(result);
        }
        public Task<GetAnimalTipoResponse> GetAnimalTipoResponse(AnimalTipo tipo)
        {
            var result = new GetAnimalTipoResponse
            {
                Descripcion = tipo.Descripcion,
            };

            return Task.FromResult(result);
        }

        public Task<List<GetAnimalTipoResponse>> GetAllAnimalTipoResponse(List<AnimalTipo> tipos)
        {
            List<GetAnimalTipoResponse> animalTipoResponses = new List<GetAnimalTipoResponse>();
            foreach (var tipo in tipos)
            {
                var result = new GetAnimalTipoResponse
                {
                    Descripcion = tipo.Descripcion,
                };
                animalTipoResponses.Add(result);
            }


            return Task.FromResult(animalTipoResponses);
        }
    }
}
