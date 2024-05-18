using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command;

public class MediaCommand : IMediaCommand
{
    private readonly AnimalDbContext _context;

    public MediaCommand(AnimalDbContext context)
    {
        _context = context;
    }

    public async Task<Media> CreateMedia(Media media)
    {
        try
        {
            _context.Medias.Add(media);
            await _context.SaveChangesAsync();
            return media;
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<Media> UpdateMedia(UpdateMediaRequest request)
    {
        try
        {
            var mediaUpdated =  _context.Medias.FirstOrDefault(f => f.Id == request.Id);
            mediaUpdated.url = request.url;
            await _context.SaveChangesAsync();
            return mediaUpdated;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
    public async Task<Media> DeleteMedia(DeleteMediaRequest request)
    {
        try
        {
            var mediaDeleted = _context.Medias.FirstOrDefault(f => f.Id == request.AnimalId);
            _context.Medias.Remove(mediaDeleted);
            await _context.SaveChangesAsync();
            return new Media();
        }
        catch (DbUpdateException)
        {
            throw new Conflict("Error en la base de datos");
        }
    }
}
