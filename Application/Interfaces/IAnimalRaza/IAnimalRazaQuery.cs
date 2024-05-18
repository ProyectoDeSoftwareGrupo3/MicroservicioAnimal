using Domain.Entities;

namespace Application.Interfaces;
    public interface IAnimalRazaQuery
    {
        Task<List<AnimalRaza>> GetListAnimalRaza();
        Task<AnimalRaza> GetAnimalRazaById(int id);
    }
