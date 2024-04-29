using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IAnimalTipo;
public interface IAnimalTipoService
{
    Task<CreateAnimalTipoResponse> CreateAnimalTipo(CreateAnimalTipoRequest request);
    Task<CreateAnimalTipoResponse> DeleteAnimalTipo(DeleteAnimalTipoRequest request);
    Task<GetAnimalTipoResponse> UpdateAnimalTipo(UpdateAnimalTipoRequest request);
    Task<List<GetAnimalTipoResponse>> GetListAnimalTipo();
    Task<GetAnimalTipoResponse> GetAnimalTipoById(int id);

}
