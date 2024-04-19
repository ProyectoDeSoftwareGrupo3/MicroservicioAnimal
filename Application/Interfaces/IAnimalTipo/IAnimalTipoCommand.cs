using Domain.Entities;

namespace Application.Interfaces.IAnimalTipo;

public interface IAnimalTipoCommand
{   
    Task<AnimalTipo> CreateAnimalTipo(AnimalTipo animalTipo);
}
