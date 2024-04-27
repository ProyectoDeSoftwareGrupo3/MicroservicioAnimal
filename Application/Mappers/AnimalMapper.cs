using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class AnimalMapper:IAnimalMapper
    {
        private readonly IGaleriaMapper _galeriaMapper;
        private readonly IAnimalTipoMapper _animalTipoMapper;

        public AnimalMapper(IGaleriaMapper galeriaMapper,IAnimalTipoMapper animalTipoMapper)
        {
            _animalTipoMapper = animalTipoMapper;
            _galeriaMapper = galeriaMapper;
        }
            
        public async Task<GetAnimalResponse> CreateGetAnimalResponse(Animal animal)
        {
            var response = new GetAnimalResponse
            {
                Adoptado = animal.Adoptado,
                Edad = animal.Edad,
                Genero = animal.Genero,
                Historia = animal.Historia,
                Id = animal.Id,
                Nombre = animal.Nombre,
                Peso = animal.Peso,
                TipoAnimal = await _animalTipoMapper.CreateAnimalTipoResponse(animal.Tipo),
                Galeria = await _galeriaMapper.CreateAnimalGaleriaResponse(animal.Galeria),
            };
            return response;
        }
    }
}
