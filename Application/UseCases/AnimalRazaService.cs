using Application.Interfaces.IAnimalRaza;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AnimalRazaService: IAnimalRazaService
    {
        private readonly IAnimalRazaQuery _animalRazaQuery;
        private readonly IAnimalRazaCommand _animalRazaCommand;

        public AnimalRazaService(IAnimalRazaQuery animalRazaQuery, IAnimalRazaCommand animalRazaCommand)
        {
            _animalRazaQuery = animalRazaQuery;
            _animalRazaCommand = animalRazaCommand;
        }

        public async Task<CreateAnimalRazaResponse> CreateAnimalRaza(CreateAnimalRazaRequest request )
        {
            var animalRaza = new AnimalRaza
            {
                TipoId = request.TipoId,
                Descripcion = request.Descripcion
            };

            var animalRazaCreated = _animalRazaCommand.CreateAnimalRaza(animalRaza);
            return await GetCreateAnimalRazaResponse(animalRaza);
            
        }

        public async Task<CreateAnimalRazaResponse> DeleteAnimalRaza(DeleteAnimalRazaRequest request)
        {
            var animalRazaDeleted = await _animalRazaCommand.DeleteAnimalRaza(request);
            return await GetCreateAnimalRazaResponse(animalRazaDeleted);
        }

        public async Task<CreateAnimalRazaResponse> UpdateAnimalRaza(UpdateAnimalRazaRequest request)
        {
            var animalRazaUpdated = await _animalRazaCommand.UpdateAnimalRaza(request);
        return await GetCreateAnimalRazaResponse(animalRazaUpdated);
        }
        public async Task<AnimalRaza> GetAnimalRazaById(int id)
        {
            return await _animalRazaQuery.GetAnimalRazaById(id);
        }

        public async Task<List<AnimalRaza>> GetListAnimalRaza()
        {
            return await _animalRazaQuery.GetListAnimalRaza();
        }

        private Task<CreateAnimalRazaResponse>GetCreateAnimalRazaResponse(AnimalRaza animalRaza)
        {
            return Task.FromResult(new CreateAnimalRazaResponse
            {
                Id = animalRaza.Id,
                TipoId = animalRaza.TipoId,
                Descripcion = animalRaza.Descripcion
            });
        }
    }
}
