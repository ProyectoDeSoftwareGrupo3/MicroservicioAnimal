using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IAnimalRaza
{
    public interface IAnimalRazaCommand
    {
        Task<AnimalRaza> CreateAnimalRaza(AnimalRaza animalRaza);
    }
}
