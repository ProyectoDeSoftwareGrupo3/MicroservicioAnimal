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
        public Task<GetAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza)
        {
            var result = new GetAnimalRazaResponse
            {
                Descripcion = raza.Descripcion,
            };
            return Task.FromResult(result);
        }
    }
}
