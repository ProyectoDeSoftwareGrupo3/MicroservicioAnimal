using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases;

public class MediaServices : IMediaServices
{
    private readonly IMediaCommand _mediaCommand;
    private readonly IMediaQuery _mediaQuery;
    private readonly IMediaMapper _mediaMapper;
    private readonly IAnimalQuery _animalQuery;


    public MediaServices(IMediaCommand mediaCommand, IMediaQuery mediaQuery,IMediaMapper mediaMapper, IAnimalQuery animalQuery)
    {

        _mediaCommand = mediaCommand;
        _mediaQuery = mediaQuery;
        _mediaMapper = mediaMapper;
        _animalQuery = animalQuery;
    }

    public async Task<CreateMediaResponse> CreateMedia(CreateMediaRequest request)
    {
        try
        {
            if (!await CheckAnimalId(request.AnimalId))
            {
                throw new ExceptionNotFound("No Existe animal con ese Id");
            }

            var media = new Media
            {
                url = request.url,
                AnimalId = request.AnimalId,   
            };

            var mediaCreated = await _mediaCommand.CreateMedia(media);
            return await _mediaMapper.CreateMediaResponse(mediaCreated);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }


    }

    public async Task<GetMediaReponse> UpdateMedia(UpdateMediaRequest request)
    {
        try
        {
            if (!await CheckMediaId(request.Id))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _mediaCommand.UpdateMedia(request);
            return await _mediaMapper.GetMediaResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }
    public async Task<CreateMediaResponse> DeleteMedia(DeleteMediaRequest request)
    {
        try
        {
            if (!await CheckMediaId(request.AnimalId))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _mediaCommand.DeleteMedia(request);
            return await _mediaMapper.CreateMediaResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<GetMediaReponse> GetMediaById(int id)
    {
        try
        {
            if (!await CheckMediaId(id))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _mediaQuery.GetMediaById(id);
            return await _mediaMapper.GetMediaResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }
        
    }

    public async Task<List<GetMediaReponse>> GetListMedia()
    {
        var list = await _mediaQuery.GetListMedia();
        return await _mediaMapper.CreateListMediaResponse(list);
    }


    private async Task<bool> CheckAnimalId(int id)
    {
        return (await _animalQuery.GetAnimalById(id) != null);

    }
    private async Task<bool> CheckMediaId(int id)
    {
        return (await _mediaQuery.GetMediaById(id)!=null);

    }
}
