using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class AnimalTipoMapper : IAnimalTipoMapper
    {
        private readonly IAnimalRazaMapper _animalRazaMapper;
        public AnimalTipoMapper(IAnimalRazaMapper animalRazaMapper)
        {
            _animalRazaMapper = animalRazaMapper;
        }
        public async Task<CreateAnimalTipoResponse> CreateAnimalTipoResponse(AnimalTipo tipo)
        {
            var result = new CreateAnimalTipoResponse
            {
                id = tipo.Id,
                Descripcion = tipo.Descripcion,
                Raza = await _animalRazaMapper.CreateAnimalRazaResponse(tipo.Razas.FirstOrDefault())
            };

            return result;
        }
    }
}
