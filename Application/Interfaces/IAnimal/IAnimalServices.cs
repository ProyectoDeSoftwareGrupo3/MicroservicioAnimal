using Application.Request;
using Application.Response;

namespace Application;

public interface IAnimalServices
{
    Task<GetAnimalResponse> CreateAnimal(CreateAnimalRequest request, string userId);
    Task<GetAnimalResponse> UpdateAnimal(UpdateAnimalRequest request);
    Task<DeleteAnimalResponse> DeleteAnimal(int id);
    Task<List<GetAnimalResponse>> GetListAnimal(decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId);
    Task<GetAnimalResponse> GetAnimalById(int id);

    Task<GetAnimalResponse> AddMedia(CreateMediaRequest request);
    Task<GetAnimalResponse> DeleteMedia(DeleteMediaRequest request);
}
