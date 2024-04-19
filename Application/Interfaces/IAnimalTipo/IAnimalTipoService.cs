using Application.Request;
using Application.Response;

namespace Application.Interfaces.IAnimalTipo;
public interface IAnimalTipoService
{
    Task<CreateAnimalTipoResponse> CreateAnimalTipo(CreateAnimalTipoRequest request);
}
