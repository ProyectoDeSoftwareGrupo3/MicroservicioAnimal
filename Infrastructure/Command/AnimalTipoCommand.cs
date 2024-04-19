using Application.Exceptions;
using Application.Interfaces.IAnimalTipo;
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
                _context.SaveChanges();
                return animalTipo;
        }
        catch(DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
