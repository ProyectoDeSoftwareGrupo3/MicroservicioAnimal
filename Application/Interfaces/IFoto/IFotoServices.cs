using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IFoto;

public interface IFotoServices
{
    Task<CreateFotoResponse> CreateFoto(CreateFotoRequest request);
    Task<GetFotoReponse> UpdateFoto(UpdateFotoRequest request);
    Task<CreateFotoResponse> DeleteFoto(DeleteFotoRequest request);
    Task<List<CreateFotoResponse>> GetListFoto();
    Task<GetFotoReponse> GetFotoById(int id);
}
