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
    Task<Animal> GetAnimalById(int id);
}
