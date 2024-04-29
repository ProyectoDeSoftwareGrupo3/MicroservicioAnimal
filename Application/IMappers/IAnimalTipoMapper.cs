using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IAnimalTipoMapper
    {
        Task<GetAnimalTipoResponse> CreateAnimalTipoResponse(AnimalTipo tipo);
    }
}
