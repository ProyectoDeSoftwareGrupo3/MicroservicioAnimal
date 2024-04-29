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
        public async Task<GetAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza)
        {
            var result = new GetAnimalRazaResponse
            {
                Descripcion = raza.Descripcion,
                Tipo = await _tipoMapper.CreateAnimalTipoResponse(raza.Tipo)

            };
            return result;
        }
    }
}
