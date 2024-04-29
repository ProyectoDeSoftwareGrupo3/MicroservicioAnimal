using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class AnimalMapper:IAnimalMapper
    {
        private readonly IAnimalRazaMapper _razaMapper;
        private readonly IFotoMapper _fotoMapper;

        public AnimalMapper(IAnimalRazaMapper razaMapper, IFotoMapper fotoMapper)
        {
            _fotoMapper = fotoMapper;
            _razaMapper = razaMapper;
        }

        public async Task<List<GetAnimalResponse>>GetAllAnimalsResponse(List<Animal> animales)
        {
            List<GetAnimalResponse> animalResponses = new List<GetAnimalResponse>();
            foreach (var animal in animales) 
            {
                var response = new GetAnimalResponse
                {
                    Genero = animal.Genero,
                    Peso = animal.Peso,
                    Adoptado = animal.Adoptado,
                    Edad = animal.Edad,


                    Historia = animal.Historia,
                    Id = animal.Id,
                    Nombre = animal.Nombre,
                    Fotos = await _fotoMapper.CreateListFotoResponse(animal.Fotos),
                    Raza = await _razaMapper.GetAnimalRazaResponse(animal.Raza),

                };
                animalResponses.Add(response);
            }
            return animalResponses;
        }

        public async Task<DeleteAnimalResponse> DeleteAnimalResponse(Animal animal)
        {
            var response = new DeleteAnimalResponse
            {
                Id = animal.Id,
                Adoptado = animal.Adoptado,
                Nombre = animal.Nombre,
                Raza = await _razaMapper.CreateAnimalRazaResponse(animal.Raza),

            };
            return response;
        }

        public async Task<GetAnimalResponse> GetAnimalResponse(Animal animal)
        {
            var response = new GetAnimalResponse
            {
                Genero = animal.Genero,
                Peso = animal.Peso,
                Adoptado = animal.Adoptado,
                Edad = animal.Edad,
                
                Historia = animal.Historia,
                Id = animal.Id,
                Nombre = animal.Nombre,

                Fotos = await _fotoMapper.CreateListFotoResponse(animal.Fotos),
                Raza = await _razaMapper.GetAnimalRazaResponse(animal.Raza),
            };
            return response;
        }
    }
}
