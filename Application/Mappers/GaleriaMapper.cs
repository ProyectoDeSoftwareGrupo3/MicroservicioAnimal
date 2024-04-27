using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class GaleriaMapper:IGaleriaMapper
    {
        private readonly IFotoMapper _fotoMapper;
        public GaleriaMapper(IFotoMapper fotoMapper) 
        {
            _fotoMapper = fotoMapper;
        }

        public async Task<CreateAnimalGaleriaResponse> CreateAnimalGaleriaResponse(AnimalGaleria galeria)
        {
            var response = new CreateAnimalGaleriaResponse
            {
                Descripcion = galeria.Descripcion,
                Id = galeria.Id,
                Fotos = await _fotoMapper.CreateListFotoResponse(galeria.Fotos)
                
            };
            return response;
        }

    }
}
