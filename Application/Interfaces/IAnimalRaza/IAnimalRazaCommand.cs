using Application.Request;
using Domain.Entities;

namespace Application.Interfaces;
public interface IAnimalRazaCommand
{
    Task<AnimalRaza> CreateAnimalRaza(AnimalRaza animalRaza);
    Task<AnimalRaza> DeleteAnimalRaza(DeleteAnimalRazaRequest request);
    Task<AnimalRaza> UpdateAnimalRaza(UpdateAnimalRazaRequest request);
}

