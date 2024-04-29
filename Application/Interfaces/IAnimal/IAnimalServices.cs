using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application;

public interface IAnimalServices
{
    Task<GetAnimalResponse> CreateAnimal(CreateAnimalRequest request);
    Task<GetAnimalResponse> UpdateAnimal(UpdateAnimalRequest request);
    Task<DeleteAnimalResponse> DeleteAnimal(int id);
    Task<List<GetAnimalResponse>> GetListAnimal();
    Task<GetAnimalResponse> GetAnimalById(int id);
    //Task<List<Animal>> GetByGender(String genero);
    //Task<List<Animal>> GetByWeight(decimal peso);
    //Task<List<Animal>> GetByAge(int edad);
}
