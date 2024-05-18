using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application;

public class AnimalTipoServices : IAnimalTipoService
{
    private readonly IAnimalTipoQuery _animalTipoquery;
    private readonly IAnimalTipoCommand _animalTipocommand;
    private readonly IAnimalTipoMapper _animalTipomapper;

    public AnimalTipoServices(IAnimalTipoQuery query, IAnimalTipoCommand command, IAnimalTipoMapper tipoMapper)
    {
        _animalTipoquery = query;
        _animalTipocommand = command;
        _animalTipomapper = tipoMapper;
    }

    public async Task<CreateAnimalTipoResponse> CreateAnimalTipo(CreateAnimalTipoRequest request)
    {
        var animalTipo = new AnimalTipo
        {
            Descripcion = request.Descripcion
        };
        var animalTipoCreated = await _animalTipocommand.CreateAnimalTipo(animalTipo);
        return await _animalTipomapper.CreateAnimalTipoResponse(animalTipoCreated);
    }
    public async Task<CreateAnimalTipoResponse> DeleteAnimalTipo(DeleteAnimalTipoRequest request)
    {
        try
        {
            if (!await CheckAnimalTipoId(request.Id))
            {
                throw new ExceptionNotFound("No Existe un Tipo de animal con ese Id");
            }
            var animalTipoDeleted = await _animalTipocommand.DeleteAnimalTipo(request);
            return await _animalTipomapper.CreateAnimalTipoResponse(animalTipoDeleted);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<GetAnimalTipoResponse> UpdateAnimalTipo(UpdateAnimalTipoRequest request)
    {
        try
        {
            if (!await CheckAnimalTipoId(request.Id))
            {
                throw new ExceptionNotFound("No Existe un Tipo de animal con ese Id");
            }
            var animalTipoUpdated = await _animalTipocommand.UpdateAnimalTipo(request);
            return await _animalTipomapper.GetAnimalTipoResponse(animalTipoUpdated);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }
    public async Task<GetAnimalTipoResponse> GetAnimalTipoById(int id)
    {
        try
        {
            if (!await CheckAnimalTipoId(id))
            {
                throw new ExceptionNotFound("No Existe un Tipo de animal con ese Id");
            }
            var animalTipoUpdated = await _animalTipoquery.GetAnimalTipoById(id);
            return await _animalTipomapper.GetAnimalTipoResponse(animalTipoUpdated);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }
        
    }

    public async Task<List<GetAnimalTipoResponse>> GetListAnimalTipo()
    {
        return await _animalTipomapper.GetAllAnimalTipoResponse(await _animalTipoquery.GetListAnimalTipo());
    }

    private async Task<bool>CheckAnimalTipoId(int id)
    {
        return (await _animalTipoquery.GetAnimalTipoById(id) != null);
    }

}
