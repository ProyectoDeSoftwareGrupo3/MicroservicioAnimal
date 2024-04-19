using Domain.Entities;

namespace Application.Interfaces.IAnimalGaleria;

public interface IAnimalGaleriaCommand
{
    Task<AnimalGaleria> CreateAnimalGaleria(AnimalGaleria animalGaleria);
}
