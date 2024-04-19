using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IAnimalGaleria;

public interface IAnimalGaleriaServices
{
    Task<CreateAnimalGaleriaResponse> CreateAnimalGaleria(CreateAnimalGaleriaRequest request);
    Task<List<AnimalGaleria>> GetListAnimalGaleria();
    Task<AnimalGaleria> GetAnimalGaleriaById(int id);
}
