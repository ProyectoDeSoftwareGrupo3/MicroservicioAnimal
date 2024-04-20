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
                return _context.AnimalesTipos.FirstOrDefault(at => at.Id == id);
            }
        catch (DbException)
            {
                throw new Conflict("Hubo un error en la busqueda del tipo");
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
                throw new Conflict("Hubo un error en la busqueda de la lista de tipos");
            }
    }
}
