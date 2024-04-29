using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class AnimalTipoMapper : IAnimalTipoMapper
    {

        public Task<GetAnimalTipoResponse> CreateAnimalTipoResponse(AnimalTipo tipo)
        {
            var result = new GetAnimalTipoResponse
            {
                Descripcion = tipo.Descripcion,   
            };

            return Task.FromResult(result);
        }
    }
}
