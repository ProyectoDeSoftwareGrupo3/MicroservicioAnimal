using Application;
using Application.Exceptions;
using Application.Interfaces.IFoto;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class FotoCommand : IFotoCommand
{
    private readonly AnimalDbContext _context;

    public FotoCommand(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<Foto> CreateFoto(Foto foto)
    {
        try
        {
            _context.Fotos.Add(foto);
            _context.SaveChanges();
            return foto;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
