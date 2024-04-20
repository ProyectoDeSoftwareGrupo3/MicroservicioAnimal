using System.Data.Common;
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
            _context.SaveChanges();
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
            var animalUpdated = _context.Animales.FirstOrDefault(a => a.Id == request.Id);
            animalUpdated.AnimalTipoId = request.AnimalTipoId;
            animalUpdated.UsuarioId = request.UsuarioId;
            animalUpdated.GaleriaId = request.GaleriaId;
            animalUpdated.Nombre = request.Nombre;
            animalUpdated.Genero = request.Genero;
            animalUpdated.Edad = request.Edad;
            animalUpdated.Peso = request.Peso;
            animalUpdated.Historia = request.Historia;
            animalUpdated.Adoptado = request.Adoptado;
            _context.SaveChanges();
            return animalUpdated;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }

    public Task<Animal> DeleteAnimal(DeleteAnimalRequest request)
    {
        try
        {
            var animalDeleted = _context.Animales.FirstOrDefault(a => a.Id == request.Id);
            _context.Animales.Remove(animalDeleted);
            _context.SaveChanges();
            return Task.FromResult(new Animal());
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }


}
