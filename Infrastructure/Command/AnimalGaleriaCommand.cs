using Application.Exceptions;
using Application.Interfaces.IAnimalGaleria;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AnimalGaleriaCommand : IAnimalGaleriaCommand
{
    private readonly AnimalDbContext _context;

    public AnimalGaleriaCommand(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalGaleria> CreateAnimalGaleria(AnimalGaleria animalGaleria)
    {
        try
        {
            _context.AnimalesGalerias.Add(animalGaleria);
            _context.SaveChanges();
            return animalGaleria;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
