using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Interfaces.IFoto;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases;

public class FotoServices : IFotoServices
{
    private readonly IFotoCommand _fotoCommand;
    private readonly IFotoQuery _fotoQuery;
    private readonly IFotoMapper _fotoMapper;
    private readonly IAnimalQuery _animalQuery;


    public FotoServices(IFotoCommand fotoCommand, IFotoQuery fotoQuery,IFotoMapper fotoMapper, IAnimalQuery animalQuery)
    {

        _fotoCommand = fotoCommand;
        _fotoQuery = fotoQuery;
        _fotoMapper = fotoMapper;
        _animalQuery = animalQuery;
    }

    public async Task<CreateFotoResponse> CreateFoto(CreateFotoRequest request)
    {
        try
        {
            if (!await CheckAnimalId(request.AnimalId))
            {
                throw new ExceptionNotFound("No Existe animal con ese Id");
            }

            var foto = new Foto
            {
                url = request.url,
                AnimalId = request.AnimalId,
            };

            var fotocreated = _fotoCommand.CreateFoto(foto);
            return await GetCreateFotoResponse(foto);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }


    }
    private Task<CreateFotoResponse> GetCreateFotoResponse(Foto foto)
    {
        return Task.FromResult(new CreateFotoResponse{
            Id = foto.Id,
            url = foto.url,
            
        });
    }
    public async Task<GetFotoReponse> UpdateFoto(UpdateFotoRequest request)
    {
        try
        {
            if (!await CheckFotoId(request.Id))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _fotoCommand.UpdateFoto(request);
            return await _fotoMapper.UpdateFotoResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }
    public async Task<CreateFotoResponse> DeleteFoto(DeleteFotoRequest request)
    {
        var result = await _fotoCommand.DeleteFoto(request);
        return await GetCreateFotoResponse(result);
    }

    public async Task<Foto> GetFotoById(int id)
    {
        return await _fotoQuery.GetFotoById(id);
    }

    public async Task<List<Foto>> GetListFoto()
    {
        return await _fotoQuery.GetListFoto();
    }


    private async Task<bool> CheckAnimalId(int id)
    {
        return (await _animalQuery.GetAnimalById(id) != null);

    }
    private async Task<bool> CheckFotoId(int id)
    {
        return (await _fotoQuery.GetFotoById(id)!=null);

    }
}
