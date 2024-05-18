using Application.Request;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalCommand
{
    Task<Animal> CreateAnimal(Animal animal);
    Task<Animal> UpdateAnimal(UpdateAnimalRequest request);
    Task<Animal> DeleteAnimal(int id);
}
