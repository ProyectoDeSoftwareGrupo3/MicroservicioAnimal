using Domain.Entities;

namespace Application.Interfaces.IFoto;

public interface IFotoQuery
{
    Task<List<Foto>> GetListFoto();
    Task<Foto> GetFotoById(int id);
}
