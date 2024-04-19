using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IAnimalGaleria;

public interface IAnimalGaleriaServices
{
    Task<CreateAnimalGaleriaResponse> CreateAnimalGaleria(CreateAnimalGaleriaRequest request);
    Task<CreateAnimalGaleriaResponse> UpdateAnimalGaleria(UpdateAnimalGaleriaRequest request);
    Task<CreateAnimalGaleriaResponse> DeleteAnimalGaleria(DeleteAnimalGaleriaRequest requests);
    Task<List<AnimalGaleria>> GetListAnimalGaleria();
    Task<AnimalGaleria> GetAnimalGaleriaById(int id);
}
