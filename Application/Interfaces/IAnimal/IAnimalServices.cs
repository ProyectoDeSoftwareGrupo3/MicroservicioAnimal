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

    Task<GetAnimalResponse> AddMedia(CreateFotoRequest request);
    Task<GetAnimalResponse> DeleteMedia(DeleteFotoRequest request);

}
