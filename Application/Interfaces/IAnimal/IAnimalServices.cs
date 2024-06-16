using Application.Request;
using Application.Response;

namespace Application;

public interface IAnimalServices
{
    Task<GetAnimalResponse> CreateAnimal(CreateAnimalRequest request, string userId);
    Task<GetAnimalResponse> UpdateAnimal(UpdateAnimalRequest request, string userId);
    Task<DeleteAnimalResponse> DeleteAnimal(int id, string userId);
    Task<List<GetAnimalResponse>> GetListAnimal(string? nombre, decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId);
    Task<GetAnimalResponse> GetAnimalById(int id);
    Task<List<GetAnimalResponse>> GetListAnimalByUserId(string userId);

    Task<GetAnimalResponse> AddMedia(CreateMediaRequest request, string userId);
    Task<GetAnimalResponse> DeleteMedia(DeleteMediaRequest request, string userId);
}
