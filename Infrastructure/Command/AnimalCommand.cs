using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class AnimalCommand : IAnimalCommand
{
    private readonly AnimalDbContext _context;

    public AnimalCommand(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<Animal> CreateAnimal(Animal animal)
    {
        try
        {
            _context.Animales.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<Animal> UpdateAnimal(UpdateAnimalRequest request)
    {
        try
        {
            Animal animalUpdated = _context.Animales.FirstOrDefault(a => a.Id == request.Id);
            animalUpdated.AnimalRazaId = request.AnimalRazaId;
            animalUpdated.Nombre = request.Nombre;
            animalUpdated.Genero = request.Genero;
            animalUpdated.Edad = request.Edad;
            animalUpdated.Peso = request.Peso;
            animalUpdated.Historia = request.Historia;
            animalUpdated.Adoptado = request.Adoptado;
            await _context.SaveChangesAsync();
            return animalUpdated;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }

    public async Task<Animal> DeleteAnimal(int id)
    {
        try
        {
            var animalDeleted = _context.Animales.FirstOrDefault(a => a.Id == id);
            _context.Animales.Remove(animalDeleted);
            await _context.SaveChangesAsync();
            return animalDeleted;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }


}
