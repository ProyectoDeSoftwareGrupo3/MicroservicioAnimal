using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query;

public class AnimalQuery : IAnimalQuery
{
    private readonly AnimalDbContext _context;

    public AnimalQuery(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<Animal> GetAnimalById(int id)
    {
        try
        {
            var result = _context.Animales.FirstOrDefault(a => a.Id == id);
            return result;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }   
    }

    public async Task<List<Animal>> GetListAnimal()
    {
        try
        {
            return await _context.Animales.ToListAsync();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }  
    }
}
