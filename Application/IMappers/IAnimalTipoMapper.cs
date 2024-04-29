using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IAnimalTipoMapper
    {
        Task<CreateAnimalTipoResponse> CreateAnimalTipoResponse(AnimalTipo tipo);
        Task<GetAnimalTipoResponse> GetAnimalTipoResponse(AnimalTipo tipo);
        Task<List<GetAnimalTipoResponse>> GetAllAnimalTipoResponse(List<AnimalTipo> tipos);
    }
}
