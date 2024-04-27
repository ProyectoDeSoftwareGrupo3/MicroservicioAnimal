using Application.Interfaces.IFoto;
using Application.Request;
using Domain.Entities;

namespace Application.UseCases;

public class FotoServices : IFotoServices
{
    private readonly IFotoCommand _fotoCommand;
    private readonly IFotoQuery _fotoQuery;


    public FotoServices(IFotoCommand fotoCommand, IFotoQuery fotoQuery)
    {
        _fotoCommand = fotoCommand;
        _fotoQuery = fotoQuery;
    }

    public async Task<CreateFotoResponse> CreateFoto(CreateFotoRequest request)
    {

        var foto = new Foto {
            url = request.url,
            GaleriaId = request.GaleriaId
        };
        var fotocreated = _fotoCommand.CreateFoto(foto);
        return await GetCreateFotoResponse(foto);
        
    }
    private Task<CreateFotoResponse> GetCreateFotoResponse(Foto foto)
    {
        return Task.FromResult(new CreateFotoResponse{
            Id = foto.Id,
            url = foto.url,
            GaleriaId = foto.GaleriaId
        });
    }
    public async Task<CreateFotoResponse> UpdateFoto(UpdateFotoRequest request)
    {
        var result = await _fotoCommand.UpdateFoto(request);
        return await GetCreateFotoResponse(result);
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
}
