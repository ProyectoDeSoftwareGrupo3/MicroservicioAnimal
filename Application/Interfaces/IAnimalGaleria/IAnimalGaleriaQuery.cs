using Domain.Entities;

namespace Application.Interfaces.IAnimalGaleria;

public interface IAnimalGaleriaQuery
{
    Task<List<AnimalGaleria>> GetListAnimalGaleria();
    Task<AnimalGaleria> GetAnimalGaleriaById(int id);
}
