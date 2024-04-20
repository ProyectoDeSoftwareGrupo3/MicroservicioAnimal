﻿using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IAnimalTipo;
public interface IAnimalTipoService
{
    Task<CreateAnimalTipoResponse> CreateAnimalTipo(CreateAnimalTipoRequest request);
    Task<CreateAnimalTipoResponse> DeleteAnimalTipo(DeleteAnimalTipoRequest request);
    Task<CreateAnimalTipoResponse> UpdateAnimalTipo(UpdateAnimalTipoRequest request);
    Task<List<AnimalTipo>> GetListAnimalTipo();
    Task<AnimalTipo>GetAnimalTipoById(int id);

}
