using Application.Request;
using Domain.Entities;

namespace Application.Interfaces;

public interface IMediaCommand
{
    Task<Media> CreateMedia(Media media);
    Task<Media> UpdateMedia(UpdateMediaRequest request);
    Task<Media> DeleteMedia(DeleteMediaRequest request);
}
