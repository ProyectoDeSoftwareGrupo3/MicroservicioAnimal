using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IAnimalRaza
{
    public interface IAnimalRazaService
    {
        Task<CreateAnimalRazaResponse> CreateAnimalRaza(CreateAnimalRazaRequest request);
        Task<CreateAnimalRazaResponse> DeleteAnimalRaza(DeleteAnimalRazaRequest request);
        Task<CreateAnimalRazaResponse> UpdateAnimalRaza(UpdateAnimalRazaRequest request);
        Task<List<AnimalRaza>> GetListAnimalRaza();
        Task<AnimalRaza>GetAnimalRazaById(int id);
    }
}
