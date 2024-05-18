using System.Data.Common;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class MediaQuery : IMediaQuery
{
    private readonly AnimalDbContext _contex;

    public MediaQuery(AnimalDbContext contex)
    {
        _contex = contex;
    }

    public async Task<Media> GetMediaById(int id)
    {
        try
        {
            return await _contex.Medias.FirstOrDefaultAsync(f => f.Id == id);
        }
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda del tipo");
        }
    }

    public async Task<List<Media>> GetListMedia()
    {
        try
        {
            return await _contex.Medias.ToListAsync();
        }
        catch (DbException)
        {
            throw new Conflict("Hubo un error en la busqueda de la lista de tipos");
        }
    }
}
