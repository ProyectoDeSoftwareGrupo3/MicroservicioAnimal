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
            var result = _context.Animales
                .Include(a => a.Tipo)
                .Include(a => a.Galeria)
                .Include(a =>a.Galeria.Fotos)
                .Include(a=>a.Tipo.Razas)
                .FirstOrDefault(a => a.Id == id);
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

    public async Task<List<Animal>> GetByGender(String genero)
    {
        try
        {
            var result = from animal in _context.Animales where animal.Genero == genero select animal;
            return result.ToList();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<List<Animal>> GetByWeight(decimal peso)
    {
        try
        {
            var result = from animal in _context.Animales where animal.Peso == peso select animal;
            return result.ToList();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<List<Animal>> GetByAge(int peso)
    {
        try
        {
            var result = from animal in _context.Animales where animal.Edad == peso select animal;
            return result.ToList();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
