using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Interfaces.IAnimalRaza;
using Application.Interfaces.IFoto;
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
    private readonly IFotoServices _fotoServices;
    public AnimalServices(IAnimalCommand animalCommand, IAnimalQuery animalQuery, IAnimalRazaQuery razaQuery, 
                            IAnimalMapper animalMapper, IFotoServices fotoServices)
    {
        _animalCommand = animalCommand;
        _animalQuery = animalQuery;
        _razaQuery = razaQuery;
        _animalMapper = animalMapper;
        _fotoServices = fotoServices;
    }

    public async Task<GetAnimalResponse> CreateAnimal(CreateAnimalRequest request)
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
                UsuarioId = request.UsuarioId,
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

    public async Task<List<GetAnimalResponse>> GetListAnimal()
    {
        return await _animalMapper.GetAllAnimalsResponse(await _animalQuery.GetListAnimal());
    }

    //public async Task<List<Animal>> GetByGender(String genero)
    //{
    //    return await _animalQuery.GetByGender(genero);
    //}

    //public async Task<List<Animal>> GetByWeight(decimal peso) 
    //{
    //    return await _animalQuery.GetByWeight(peso);
    //}
    //public async Task<List<Animal>> GetByAge(int edad) 
    //{
    //    return await _animalQuery.GetByAge(edad);
    //}

    public async Task<GetAnimalResponse> AddMedia(CreateFotoRequest request)
    {
        await CheckAnimalId(request.AnimalId);
        var mediaResponse = await _fotoServices.CreateFoto(request);        
        return await GetAnimalById(request.AnimalId);
    }
    public async Task<GetAnimalResponse> DeleteMedia(DeleteFotoRequest request)
    {
        var mediaResponse = await _fotoServices.DeleteFoto(request);
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
