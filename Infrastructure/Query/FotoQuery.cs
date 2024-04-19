using System.Data.Common;
using Application.Exceptions;
using Application.Interfaces.IFoto;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class FotoQuery : IFotoQuery
{
    private readonly AnimalDbContext _contex;

    public FotoQuery(AnimalDbContext contex)
    {
        _contex = contex;
    }

    public async Task<Foto> GetFotoById(int id)
    {
        try
        {
            return _contex.Fotos.FirstOrDefault(f => f.Id == id);
        }
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda del tipo");
        }
    }

    public async Task<List<Foto>> GetListFoto()
    {
        try
        {
            return await _contex.Fotos.ToListAsync();
        }
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda de la lista de tipos");
        }
    }
}
