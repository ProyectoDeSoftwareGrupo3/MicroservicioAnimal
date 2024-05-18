using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IAnimalRazaMapper
    {
        Task<CreateAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza);
        Task<GetAnimalRazaResponse> GetAnimalRazaResponse(AnimalRaza raza);
        Task<List<GetAnimalRazaResponse>> GetAllAnimalRazaResponse(List<AnimalRaza> raza);
    }
}
