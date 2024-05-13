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

            var fotocreated = await _fotoCommand.CreateFoto(foto);
            return await _fotoMapper.CreateFotoResponse(fotocreated);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }


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
            return await _fotoMapper.GetFotoResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }
    public async Task<CreateFotoResponse> DeleteFoto(DeleteFotoRequest request)
    {
        try
        {
            if (!await CheckFotoId(request.AnimalId))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _fotoCommand.DeleteFoto(request);
            return await _fotoMapper.CreateFotoResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }

    }

    public async Task<GetFotoReponse> GetFotoById(int id)
    {
        try
        {
            if (!await CheckFotoId(id))
            {
                throw new ExceptionNotFound("No Existe foto con ese Id");
            }
            var result = await _fotoQuery.GetFotoById(id);
            return await _fotoMapper.GetFotoResponse(result);
        }
        catch (ExceptionNotFound e)
        {

            throw new ExceptionNotFound(e.Message);
        }
        
    }

    public async Task<List<GetFotoReponse>> GetListFoto()
    {
        var list = await _fotoQuery.GetListFoto();
        return await _fotoMapper.CreateListFotoResponse(list);
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
