using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IGaleriaMapper
    {
        Task<CreateAnimalGaleriaResponse> CreateAnimalGaleriaResponse(AnimalGaleria galeria);
    }
}
