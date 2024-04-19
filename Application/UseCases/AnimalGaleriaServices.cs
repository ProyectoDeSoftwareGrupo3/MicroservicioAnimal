using Application.Interfaces.IAnimalGaleria;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases;

public class AnimalGaleriaServices : IAnimalGaleriaServices
{
    private readonly IAnimalGaleriaCommand _animalGaleriaCommand;
    private readonly IAnimalGaleriaQuery _animalGaleriaQuery;

    public AnimalGaleriaServices(IAnimalGaleriaCommand animalGaleriaCommand, IAnimalGaleriaQuery animalGaleriaQuery)
    {
        _animalGaleriaCommand = animalGaleriaCommand;
        _animalGaleriaQuery = animalGaleriaQuery;
    }

    public async Task<CreateAnimalGaleriaResponse> CreateAnimalGaleria(CreateAnimalGaleriaRequest request)
    {
        var animalGaleria = new AnimalGaleria
        {
            Descripcion = request.Descripcion
        };
        var result = _animalGaleriaCommand.CreateAnimalGaleria(animalGaleria);
        return await GetCreateAnimalGaleriaResponse(animalGaleria);

    }

    private Task<CreateAnimalGaleriaResponse> GetCreateAnimalGaleriaResponse(AnimalGaleria animalGaleria)
    {
        return Task.FromResult(new CreateAnimalGaleriaResponse
        {
            Id = animalGaleria.Id,
            Descripcion = animalGaleria.Descripcion
        });
    }
    public async Task<CreateAnimalGaleriaResponse> UpdateAnimalGaleria(UpdateAnimalGaleriaRequest request)
    {
        var result = await _animalGaleriaCommand.UpdateAnimalGaleria(request);
        return await GetCreateAnimalGaleriaResponse(result);
    }
    public async Task<CreateAnimalGaleriaResponse> DeleteAnimalGaleria(DeleteAnimalGaleriaRequest request)
    {
        var result = await _animalGaleriaCommand.DeleteAnimalGaleria(request);
        return await GetCreateAnimalGaleriaResponse(result);
    }

    public Task<AnimalGaleria> GetAnimalGaleriaById(int id)
    {
        return _animalGaleriaQuery.GetAnimalGaleriaById(id);
    }

    public Task<List<AnimalGaleria>> GetListAnimalGaleria()
    {
        return _animalGaleriaQuery.GetListAnimalGaleria();
    }
}
