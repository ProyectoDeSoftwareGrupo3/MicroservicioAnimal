using System.Data.Common;
using Application.Exceptions;
using Application.Interfaces.IAnimalTipo;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query;

public class AnimalTipoQuery : IAnimalTipoQuery
{
    private readonly AnimalDbContext _context;

    public AnimalTipoQuery(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<AnimalTipo> GetAnimalTipoById(int id)
    {
        try
            {
                return await _context.AnimalesTipos.SingleOrDefaultAsync(ar => ar.Id == id);
            }
        catch (DbException)
            {
                throw new Conflict("Hubo un error en la busqueda de la raza");
            }
    }

    public async Task<List<AnimalTipo>> GetListAnimalTipo()
    {
        try
            {
                return await _context.AnimalesTipos.ToListAsync();
            }
        catch (Exception)
            {
                throw new Conflict("Hubo un error en la busqueda de la lista de razas");
            }
    }
}
