using Application.Exceptions;
using Application.Interfaces.IAnimalRaza;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Command
{
    public class AnimalRazaCommand:IAnimalRazaCommand
    {
        private readonly AnimalDbContext _context;

        public AnimalRazaCommand(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalRaza> CreateAnimalRaza(AnimalRaza animalRaza)
        {
            try
            {
                _context.AnimalesRazas.Add(animalRaza);
                _context.SaveChanges();
                return animalRaza;
            }
            catch (DbUpdateException)
            {

                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
