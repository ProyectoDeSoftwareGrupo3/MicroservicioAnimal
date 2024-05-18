using Application.Exceptions;
using Application.IMappers;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class AnimalRazaService: IAnimalRazaService
    {
        private readonly IAnimalRazaQuery _animalRazaQuery;
        private readonly IAnimalRazaCommand _animalRazaCommand;
        private readonly IAnimalRazaMapper _animalRazaMapper;

        public AnimalRazaService(IAnimalRazaQuery animalRazaQuery, IAnimalRazaCommand animalRazaCommand, IAnimalRazaMapper animalRazaMapper)
        {
            _animalRazaQuery = animalRazaQuery;
            _animalRazaCommand = animalRazaCommand;
            _animalRazaMapper = animalRazaMapper;
        }

        public async Task<CreateAnimalRazaResponse> CreateAnimalRaza(CreateAnimalRazaRequest request )
        {
            var animalRaza = new AnimalRaza
            {
                TipoId = request.TipoId,
                Descripcion = request.Descripcion
            };

            var animalRazaCreated = await _animalRazaCommand.CreateAnimalRaza(animalRaza);
            return await _animalRazaMapper.CreateAnimalRazaResponse(await _animalRazaQuery.GetAnimalRazaById(animalRazaCreated.Id));
            
        }

        public async Task<CreateAnimalRazaResponse> DeleteAnimalRaza(DeleteAnimalRazaRequest request)
        {
            try
            {
                if (!await CheckRazaId(request.Id))
                {
                    throw new ExceptionNotFound("No Existe raza con ese Id");
                }
                var animalRazaDeleted = await _animalRazaCommand.DeleteAnimalRaza(request);
                return await _animalRazaMapper.CreateAnimalRazaResponse(animalRazaDeleted);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
            
        }

        public async Task<GetAnimalRazaResponse> UpdateAnimalRaza(UpdateAnimalRazaRequest request)
        {
            try
            {
                if (!await CheckRazaId(request.Id))
                {
                    throw new ExceptionNotFound("No Existe raza con ese Id");
                }
                var animalRazaUpdated = await _animalRazaCommand.UpdateAnimalRaza(request);
                return await _animalRazaMapper.GetAnimalRazaResponse(animalRazaUpdated);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
            
        }
        public async Task<GetAnimalRazaResponse> GetAnimalRazaById(int id)
        {
            try
            {
                if (!await CheckRazaId(id))
                {
                    throw new ExceptionNotFound("No Existe raza con ese Id");
                }

                var animalRaza= await _animalRazaQuery.GetAnimalRazaById(id);
                return await _animalRazaMapper.GetAnimalRazaResponse(animalRaza);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
            
        }

        public async Task<List<GetAnimalRazaResponse>> GetListAnimalRaza()
        {
            return await _animalRazaMapper.GetAllAnimalRazaResponse(await _animalRazaQuery.GetListAnimalRaza());
        }

        private async Task<bool> CheckRazaId(int id)
        {
            return (await _animalRazaQuery.GetAnimalRazaById(id) != null);

        }

    }
}
