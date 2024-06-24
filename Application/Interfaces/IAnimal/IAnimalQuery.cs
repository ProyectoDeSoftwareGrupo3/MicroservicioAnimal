using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalQuery
{
    Task<List<Animal>> GetListAnimal(string? nombre, decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId, string? localidad);
    Task<List<Animal>> GetListAnimalByUserId(string userId);
    Task<Animal> GetAnimalById(int id);
    
}
