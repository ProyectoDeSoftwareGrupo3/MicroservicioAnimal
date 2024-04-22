using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalQuery
{
    Task<List<Animal>> GetListAnimal();
    Task<Animal> GetAnimalById(int id);
    Task<List<Animal>> GetByGender(String genero);
    Task<List<Animal>> GetByWeight(decimal peso);
    Task<List<Animal>> GetByAge(int edad);
}
