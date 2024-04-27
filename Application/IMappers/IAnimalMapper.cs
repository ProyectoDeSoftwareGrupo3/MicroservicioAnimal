using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IAnimalMapper
    {
        Task<GetAnimalResponse> CreateGetAnimalResponse(Animal animal);
    }
}
