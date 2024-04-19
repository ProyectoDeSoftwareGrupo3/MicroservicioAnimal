using Domain.Entities;

namespace Application.Interfaces.IFoto;

public interface IFotoCommand
{
    Task<Foto> CreateFoto(Foto foto);
}
