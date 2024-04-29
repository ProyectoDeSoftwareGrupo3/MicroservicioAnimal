using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IMappers
{
    public interface IAnimalRazaMapper
    {
        Task<CreateAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza);
        Task<GetAnimalRazaResponse> GetAnimalRazaResponse(AnimalRaza raza);
        Task<List<GetAnimalRazaResponse>> GetAllAnimalRazaResponse(List<AnimalRaza> raza);
    }
}
