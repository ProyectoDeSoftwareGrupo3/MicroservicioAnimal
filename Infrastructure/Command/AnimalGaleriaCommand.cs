using System.Data.Common;
using Application;
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

    public Task<AnimalGaleria> DeleteAnimalGaleria(DeleteAnimalGaleriaRequest requests)
    {
        try
        {
            var animalGaleriaDeleted = _context.AnimalesGalerias.FirstOrDefault(ag => ag.Id == requests.Id);
            _context.AnimalesGalerias.Remove(animalGaleriaDeleted);
            _context.SaveChanges();
            return Task.FromResult(new AnimalGaleria());
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }

    public Task<AnimalGaleria> UpdateAnimalGaleria(UpdateAnimalGaleriaRequest request)
    {
        try{
            var animalGaleriaUpdated = _context.AnimalesGalerias.FirstOrDefault(ag => ag.Id == request.Id);
            animalGaleriaUpdated.Descripcion = request.Descripcion;
            _context.SaveChanges();
            return Task.FromResult(animalGaleriaUpdated);
        }
        catch (DbException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
