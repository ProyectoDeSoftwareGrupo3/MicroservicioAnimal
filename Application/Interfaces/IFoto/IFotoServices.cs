using Application.Request;
using Domain.Entities;

namespace Application.Interfaces.IFoto;

public interface IFotoServices
{
    Task<CreateFotoResponse> CreateFoto(CreateFotoRequest request);
    Task<CreateFotoResponse> UpdateFoto(UpdateFotoRequest request);
    Task<CreateFotoResponse> DeleteFoto(DeleteFotoRequest request);
    Task<List<Foto>> GetListFoto();
    Task<Foto> GetFotoById(int id);
}
