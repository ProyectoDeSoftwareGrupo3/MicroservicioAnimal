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
            await CheckRazaId(request.RazaId);
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
    public async Task<GetAnimalResponse> UpdateAnimal(UpdateAnimalRequest request, string userId)
    {
        try
        {
            await CheckAnimalId(request.Id);
            await CheckUserId(userId, request.Id);
            await CheckRazaId(request.AnimalRazaId);
            var animalUpdated = await _animalCommand.UpdateAnimal(request);
            return await _animalMapper.GetAnimalResponse(await _animalQuery.GetAnimalById(request.Id));
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }
    }

    public async Task<DeleteAnimalResponse> DeleteAnimal(int id, string userId)
    {
        try
        {
            await CheckAnimalId(id);
            await CheckUserId(userId, id);
            var animalDeleted = await _animalCommand.DeleteAnimal(id);
            return await _animalMapper.DeleteAnimalResponse(animalDeleted);
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
            var animal = await _animalQuery.GetAnimalById(id);

            return animal == null ? throw new ExceptionNotFound("No Existe animal con ese Id") : await _animalMapper.GetAnimalResponse(animal);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<List<GetAnimalResponse>> GetListAnimal(string? nombre, decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId)
    {
        return await _animalMapper.GetAllAnimalsResponse(await _animalQuery.GetListAnimal(nombre, peso, edad, genero, tipoId, razaId));
    }



    public async Task<GetAnimalResponse> AddMedia(CreateMediaRequest request, string userId)
    {
        await CheckAnimalId(request.AnimalId);
        await CheckUserId(userId, request.AnimalId);
        var mediaResponse = await _mediaServices.CreateMedia(request);
        return await GetAnimalById(request.AnimalId);
    }
    public async Task<GetAnimalResponse> DeleteMedia(DeleteMediaRequest request, string userId)
    {
        await CheckUserId(userId, request.AnimalId);
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
    private async Task CheckRazaId(int id)
    {
        if(await _razaQuery.GetAnimalRazaById(id) == null)
        {
            throw new ExceptionNotFound("No Existe raza con ese Id");
        }
    }
    private async Task CheckUserId(string id, int animalId)
    {
        Animal animal = await _animalQuery.GetAnimalById(animalId);
        if(animal.UsuarioId != id)
        {
            throw new NotAuthorizedException("Usuario incorrecto");
        }
    }

    public async Task<List<GetAnimalResponse>> GetListAnimalByUserId(string userId)
    {
        return await _animalMapper.GetAllAnimalsResponse(await _animalQuery.GetListAnimalByUserId(userId));
    }
}
