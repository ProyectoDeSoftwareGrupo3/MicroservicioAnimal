using Domain.Entities;

namespace Application.Interfaces.IAnimalGaleria;

public interface IAnimalGaleriaCommand
{
    Task<AnimalGaleria> CreateAnimalGaleria(AnimalGaleria animalGaleria);
    Task<AnimalGaleria> UpdateAnimalGaleria(UpdateAnimalGaleriaRequest request);
    Task<AnimalGaleria> DeleteAnimalGaleria(DeleteAnimalGaleriaRequest requests);
}
