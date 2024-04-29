using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Interfaces.IAnimalRaza;
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
    public AnimalServices(IAnimalCommand animalCommand, IAnimalQuery animalQuery,IAnimalRazaQuery razaQuery ,IAnimalMapper animalMapper)
    {
        _animalCommand = animalCommand;
        _animalQuery = animalQuery;
        _razaQuery = razaQuery;
        _animalMapper = animalMapper;
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
            if (!await CheckAnimalId(request.Id))
            {
                throw new ExceptionNotFound("No Existe animal con ese Id");
            }
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
            if (!await CheckAnimalId(id))
            {
                throw new ExceptionNotFound("No Existe animal con ese Id");
            }
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
            if (!await CheckAnimalId(id))
            {
                throw new ExceptionNotFound("No Existe animal con ese Id");
            }
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

    private async Task<bool> CheckAnimalId(int id)
    {
        return (await _animalQuery.GetAnimalById(id) != null);

    }
    private async Task<bool> CheckRazaId(int id)
    {
        return (await _razaQuery.GetAnimalRazaById(id) != null);

    }
}
