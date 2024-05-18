using Application.Request;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalTipoCommand
{   
    Task<AnimalTipo> CreateAnimalTipo(AnimalTipo animalTipo);
    Task<AnimalTipo> DeleteAnimalTipo(DeleteAnimalTipoRequest request);
    Task<AnimalTipo> UpdateAnimalTipo(UpdateAnimalTipoRequest request);
}
