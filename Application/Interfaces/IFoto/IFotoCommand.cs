using Application.Request;
using Domain.Entities;

namespace Application.Interfaces.IFoto;

public interface IFotoCommand
{
    Task<Foto> CreateFoto(Foto foto);
    Task<Foto> UpdateFoto(UpdateFotoRequest request);
    Task<Foto> DeleteFoto(DeleteFotoRequest request);
}
