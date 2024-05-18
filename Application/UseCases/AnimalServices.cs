using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;


namespace Application.UseCases;

public class AnimalServices : IAnimalServices
{
    private readonly IAnimalCommand _animalCommand;
    private readonly IAnimalQuery _animalQuery;
    private readonly IAnimalMapper _animalMapper;
    private readonly IAnimalRazaQuery _razaQuery;
    private readonly IMediaServices _mediaServices;
    public AnimalServices(IAnimalCommand animalCommand, IAnimalQuery animalQuery,IAnimalRazaQuery razaQuery ,IAnimalMapper animalMapper, IMediaServices mediaServices)
    {
        _animalCommand = animalCommand;
        _animalQuery = animalQuery;
        _razaQuery = razaQuery;
        _animalMapper = animalMapper;
        _mediaServices = mediaServices;
    }

    public async Task<GetAnimalResponse> CreateAnimal(CreateAnimalRequest request, string userId)
    {
        try
        {
            if (!await CheckRazaId(request.RazaId))
            {
                throw new Conflict("No Existe raza con ese Id");
            }
            var animal = new Animal
            {
                AnimalRazaId = request.RazaId,
                UsuarioId = userId,
                Nombre = request.Nombre,
                Genero = request.Genero,
                Edad = request.Edad,
                Peso = request.Peso,
                Historia = request.Historia
            };
            var result = await _animalCommand.CreateAnimal(animal);
            return await _animalMapper.GetAnimalResponse(result);
        }
        catch (Conflict e)
        {

            throw new Conflict(e.Message);
        }

    }
    public async Task<GetAnimalResponse> UpdateAnimal(UpdateAnimalRequest request)
    {
        try
        {
            await CheckAnimalId(request.Id);
            if (!await CheckRazaId(request.AnimalRazaId))
            {
                throw new ExceptionNotFound("No Existe raza con ese Id");
            }
            var animalUpdated = await _animalCommand.UpdateAnimal(request);
            return await _animalMapper.GetAnimalResponse(await _animalQuery.GetAnimalById(request.Id));
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }
    }

    public async Task<DeleteAnimalResponse> DeleteAnimal(int id)
    {
        try
        {
            await CheckAnimalId(id);
            var animalDeleted = await _animalCommand.DeleteAnimal(id);
            return await _animalMapper.DeleteAnimalResponse( animalDeleted);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }


    public async Task<GetAnimalResponse> GetAnimalById(int id)
    {

        try
        {
            await CheckAnimalId(id);      
            var animal = await _animalQuery.GetAnimalById(id);
            return await _animalMapper.GetAnimalResponse(animal);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<List<GetAnimalResponse>> GetListAnimal(decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId)
    {
        return await _animalMapper.GetAllAnimalsResponse(await _animalQuery.GetListAnimal(peso, edad, genero, tipoId, razaId));
    }



    public async Task<GetAnimalResponse> AddMedia(CreateMediaRequest request)
    {
        await CheckAnimalId(request.AnimalId);
        var mediaResponse = await _mediaServices.CreateMedia(request);
        return await GetAnimalById(request.AnimalId);
    }
    public async Task<GetAnimalResponse> DeleteMedia(DeleteMediaRequest request)
    {
        var mediaResponse = await _mediaServices.DeleteMedia(request);
        return await GetAnimalById(request.AnimalId);
    }

    private async Task CheckAnimalId(int id)
    {
        if (await _animalQuery.GetAnimalById(id) == null)
        {
            throw new ExceptionNotFound("No Existe animal con ese Id");
        }
    }
    private async Task<bool> CheckRazaId(int id)
    {
        return (await _razaQuery.GetAnimalRazaById(id) != null);

    }

}
