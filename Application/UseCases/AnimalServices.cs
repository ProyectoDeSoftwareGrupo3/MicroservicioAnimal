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
    public AnimalServices(IAnimalCommand animalCommand, IAnimalQuery animalQuery, IAnimalMapper animalMapper)
    {
        _animalCommand = animalCommand;
        _animalQuery = animalQuery;
        _animalMapper = animalMapper;
    }

    public async Task<CreateAnimalResponse> CreateAnimal(CreateAnimalRequest request)
    {
        var animal = new Animal 
        {
            AnimalTipoId = request.AnimalTipoId,
            UsuarioId = request.UsuarioId,
            GaleriaId = request.GaleriaId,
            Nombre = request.Nombre,
            Genero = request.Genero,
            Edad = request.Edad,
            Peso = request.Peso,
            Historia = request.Historia,
            Adoptado = request.Adoptado
        };
        var result = _animalCommand.CreateAnimal(animal);
        return await GetCreateAnimalResponse(animal);
    }
    public async Task<CreateAnimalResponse> UpdateAnimal(UpdateAnimalRequest request)
    {
        var animalUpdated = await _animalCommand.UpdateAnimal(request);
        return await GetCreateAnimalResponse(animalUpdated);
    }

    public async Task<CreateAnimalResponse> DeleteAnimal(DeleteAnimalRequest request)
    {
        var animalDeleted = await _animalCommand.DeleteAnimal(request);
        return await GetCreateAnimalResponse(animalDeleted);
    }
    private Task<CreateAnimalResponse> GetCreateAnimalResponse(Animal animal)
    {
        return Task.FromResult(new CreateAnimalResponse
        {
            Id = animal.Id,
            AnimalTipoId = animal.AnimalTipoId,
            UsuarioId = animal.UsuarioId,
            GaleriaId = animal.GaleriaId,
            Nombre = animal.Nombre,
            Genero = animal.Genero,
            Edad = animal.Edad,
            Peso = animal.Peso,
            Historia = animal.Historia,
            Adoptado = animal.Adoptado
        });
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
            return await _animalMapper.CreateGetAnimalResponse(animal);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<List<Animal>> GetListAnimal()
    {
        return await _animalQuery.GetListAnimal();
    }

    public async Task<List<Animal>> GetByGender(String genero)
    {
        return await _animalQuery.GetByGender(genero);
    }

    public async Task<List<Animal>> GetByWeight(decimal peso) 
    {
        return await _animalQuery.GetByWeight(peso);
    }
    public async Task<List<Animal>> GetByAge(int edad) 
    {
        return await _animalQuery.GetByAge(edad);
    }

    private async Task<bool> CheckAnimalId(int id)
    {
        return (await _animalQuery.GetAnimalById(id)!=null);

    }
}
