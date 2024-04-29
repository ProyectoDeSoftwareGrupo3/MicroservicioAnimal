using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IAnimalMapper
    {
        Task<GetAnimalResponse> GetAnimalResponse(Animal animal);
        Task<DeleteAnimalResponse> DeleteAnimalResponse(Animal animal);
        Task<List<GetAnimalResponse>> GetAllAnimalsResponse(List<Animal> animales);
    }
}
