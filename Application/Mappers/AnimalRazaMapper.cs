using Application.IMappers;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AnimalRazaMapper : IAnimalRazaMapper
    {
        private readonly IAnimalTipoMapper _tipoMapper;
        public AnimalRazaMapper(IAnimalTipoMapper tipoMapper)
        {
            _tipoMapper = tipoMapper;
        }
        public async Task<CreateAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza)
        {
            var result = new CreateAnimalRazaResponse
            {
                Id= raza.Id,
                Descripcion = raza.Descripcion,
                Tipo = await _tipoMapper.GetAnimalTipoResponse(raza.Tipo)

            };
            return result;
        }

        public async Task<List<GetAnimalRazaResponse>> GetAllAnimalRazaResponse(List<AnimalRaza> razas)
        {
            List<GetAnimalRazaResponse> animalResponses = new List<GetAnimalRazaResponse>();
            foreach (var raza  in razas)
            {
                var response = new GetAnimalRazaResponse
                {
                    Descripcion = raza.Descripcion,
                    Tipo = await _tipoMapper.GetAnimalTipoResponse(raza.Tipo)
                };
                animalResponses.Add(response);
            }

            return animalResponses;
        }

        public async Task<GetAnimalRazaResponse> GetAnimalRazaResponse(AnimalRaza raza)
        {
            var result = new GetAnimalRazaResponse
            {
                Descripcion = raza.Descripcion,
                Tipo = await _tipoMapper.GetAnimalTipoResponse(raza.Tipo)

            };
            return result;
        }
    }
}
