using Application.Request;
using Application.Response;

namespace Application.Interfaces;

public interface IAnimalRazaService
{
    Task<CreateAnimalRazaResponse> CreateAnimalRaza(CreateAnimalRazaRequest request);
    Task<CreateAnimalRazaResponse> DeleteAnimalRaza(DeleteAnimalRazaRequest request);
    Task<GetAnimalRazaResponse> UpdateAnimalRaza(UpdateAnimalRazaRequest request);
    Task<List<GetAnimalRazaResponse>> GetListAnimalRaza();
    Task<GetAnimalRazaResponse> GetAnimalRazaById(int id);
}

