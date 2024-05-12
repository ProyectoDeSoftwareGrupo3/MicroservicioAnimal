using Application;
using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IFotoMapper
    {
        Task<List<CreateFotoResponse>> CreateListFotoResponse(List<Foto> fotos);
        Task<GetFotoReponse> GetFotoResponse(Foto foto);
        Task<CreateFotoResponse> CreateFotoResponse(Foto foto);
    }
}
