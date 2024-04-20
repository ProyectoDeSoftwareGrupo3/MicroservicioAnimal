using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalQuery
{
    Task<List<Animal>> GetListAnimal();
    Task<Animal> GetAnimalById(int id);
}
