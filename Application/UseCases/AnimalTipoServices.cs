using Application.Interfaces.IAnimalTipo;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application;

public class AnimalTipoServices : IAnimalTipoService
{
    private readonly IAnimalTipoQuery _animalTipoquery;
    private readonly IAnimalTipoCommand _animalTipocommand;

    public AnimalTipoServices(IAnimalTipoQuery query, IAnimalTipoCommand command)
    {
        _animalTipoquery = query;
        _animalTipocommand = command;
    }

    public async Task<CreateAnimalTipoResponse> CreateAnimalTipo(CreateAnimalTipoRequest request)
    {
        var animalTipo = new AnimalTipo
        {
            AnimalRazaId = request.AnimalRazaId,
            Descripcion = request.Descripcion
        };
        var animalTipoCreated = _animalTipocommand.CreateAnimalTipo(animalTipo);
        return await GetCreateAnimalTipoResponse(animalTipo);
    }
    private Task<CreateAnimalTipoResponse> GetCreateAnimalTipoResponse(AnimalTipo animalTipo)
    {
        return Task.FromResult(new CreateAnimalTipoResponse
        {
            id = animalTipo.Id,
            Descripcion = animalTipo.Descripcion,
            AnimalRazaId = animalTipo.AnimalRazaId
        });
    }
    public async Task<AnimalTipo> GetAnimalTipoById(int id)
    {
        return await _animalTipoquery.GetAnimalTipoById(id);
    }

    public async Task<List<AnimalTipo>> GetListAnimalTipo()
    {
        var animalTipos = await _animalTipoquery.GetListAnimalTipo();
        return animalTipos;
    }
}
