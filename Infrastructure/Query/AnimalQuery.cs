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
            var result =await _context.Animales
                .Include(a =>a.Raza)
                .Include(a=>a.Fotos)
                .Include(a=>a.Raza.Tipo)
                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }   
    }

    public async Task<List<Animal>> GetListAnimal(decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId)
    {
        try
        {
            var query = _context.Animales
                .Include(a => a.Raza)
                .Include(a => a.Fotos)
                .Include(a => a.Raza.Tipo)
                .AsQueryable();

            if (peso != null)
            {
                query = query.Where(a => a.Peso == peso);
            }
            if (edad != null)
            {
                query = query.Where(a => a.Edad == edad);
            }
            if (genero != null)
            {
                query = query.Where(a => a.Genero == genero);
            }
            if (tipoId != null)
            {
                query = query.Where(a => a.Raza.TipoId == tipoId);
            }
            if (razaId != null)
            {
                query = query.Where(a => a.Raza.Id == razaId);
            }

            return await query.ToListAsync();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
