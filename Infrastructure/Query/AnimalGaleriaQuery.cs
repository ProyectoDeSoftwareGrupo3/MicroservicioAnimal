using System.Data.Common;
using Application.Exceptions;
using Application.Interfaces.IAnimalGaleria;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AnimalGaleriaQuery : IAnimalGaleriaQuery
{
    private readonly AnimalDbContext _context;

    public AnimalGaleriaQuery(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalGaleria> GetAnimalGaleriaById(int id)
    {
        try
        {
            return _context.AnimalesGalerias.FirstOrDefault(a => a.Id == id);
        }
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda del tipo");
        }
    }

    public async Task<List<AnimalGaleria>> GetListAnimalGaleria()
    {
        try
        {
            return await _context.AnimalesGalerias.ToListAsync();
        }   
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda del tipo");
        }
    }
}
