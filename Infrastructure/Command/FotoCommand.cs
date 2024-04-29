using Application;
using Application.Exceptions;
using Application.Interfaces.IFoto;
using Application.Request;
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
    public async Task<Foto> UpdateFoto(UpdateFotoRequest request)
    {
        try
        {
            var fotoUpdated =  _context.Fotos.FirstOrDefault(f => f.Id == request.Id);
            fotoUpdated.url = request.url;
            _context.SaveChanges();
            return fotoUpdated;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<Foto> DeleteFoto(DeleteFotoRequest request)
    {
        try
        {
            var fotoDeleted = _context.Fotos.FirstOrDefault(f => f.Id == request.Id);
            _context.Fotos.Remove(fotoDeleted);
            _context.SaveChanges();
            return new Foto();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
