using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
                await _context.SaveChangesAsync();
                return animalRaza;
            }
            catch (DbUpdateException)
            {

                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<AnimalRaza> DeleteAnimalRaza(DeleteAnimalRazaRequest request)
        {
            try
            {
                var animalRazaDeleted = _context.AnimalesRazas.FirstOrDefault(ar => ar.Id == request.Id);
                _context.AnimalesRazas.Remove(animalRazaDeleted);
                await _context.SaveChangesAsync();
                return animalRazaDeleted;
            }
            catch (DbUpdateException)
            {

                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<AnimalRaza> UpdateAnimalRaza(UpdateAnimalRazaRequest request)
        {
            try
            {
                var animalRazaUpdated = _context.AnimalesRazas.FirstOrDefault(ar => ar.Id == request.Id);
                animalRazaUpdated.TipoId = request.TipoId;
                animalRazaUpdated.Descripcion = request.Descripcion;
                await _context.SaveChangesAsync();
                return animalRazaUpdated;
            }
            catch (DbException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
