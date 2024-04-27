using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application;

public interface IAnimalServices
{
    Task<CreateAnimalResponse> CreateAnimal(CreateAnimalRequest request);
    Task<CreateAnimalResponse> UpdateAnimal(UpdateAnimalRequest request);
    Task<CreateAnimalResponse> DeleteAnimal(DeleteAnimalRequest request);
    Task<List<Animal>> GetListAnimal();
    Task<GetAnimalResponse> GetAnimalById(int id);
    Task<List<Animal>> GetByGender(String genero);
    Task<List<Animal>> GetByWeight(decimal peso);
    Task<List<Animal>> GetByAge(int edad);
}
