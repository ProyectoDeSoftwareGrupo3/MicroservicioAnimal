using Domain.Entities;

namespace Application.Interfaces.IAnimalTipo;

public interface IAnimalTipoQuery
{
        Task<List<AnimalTipo>> GetListAnimalTipo();
        Task<AnimalTipo> GetAnimalTipoById(int id);
}
