using Application;
using Application.Response;
using Domain.Entities;

namespace Application.IMappers
{
    public interface IFotoMapper
    {
        Task<List<GetFotoReponse>> CreateListFotoResponse(List<Foto> fotos);
    }
}
