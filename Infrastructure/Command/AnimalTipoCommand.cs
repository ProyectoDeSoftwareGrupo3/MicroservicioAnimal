using Application.Exceptions;
using Application.Interfaces.IAnimalTipo;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class AnimalTipoCommand : IAnimalTipoCommand
{
    private readonly AnimalDbContext _context;

    public AnimalTipoCommand(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalTipo> CreateAnimalTipo(AnimalTipo animalTipo)
    {
        try{
                _context.AnimalesTipos.Add(animalTipo);
                await _context.SaveChangesAsync();
                return animalTipo;
        }
        catch(DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }

    public async Task<AnimalTipo> DeleteAnimalTipo(DeleteAnimalTipoRequest request)
    {
        var animalTipoDeleted =  _context.AnimalesTipos.FirstOrDefault(at => at.Id == request.Id);
        _context.AnimalesTipos.Remove(animalTipoDeleted);
        await _context.SaveChangesAsync();
        return animalTipoDeleted;
    }

    public async Task<AnimalTipo> UpdateAnimalTipo(UpdateAnimalTipoRequest request)
    {
        try{
            var animalTipoUpdated = _context.AnimalesTipos.FirstOrDefault(at => at.Id == request.Id);
            animalTipoUpdated.Descripcion = request.Descripcion;
            await _context.SaveChangesAsync();
            return animalTipoUpdated;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
