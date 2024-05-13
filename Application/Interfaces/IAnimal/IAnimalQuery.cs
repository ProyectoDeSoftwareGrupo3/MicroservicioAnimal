﻿using Domain.Entities;

namespace Application.Interfaces;

public interface IAnimalQuery
{
    Task<List<Animal>> GetListAnimal(decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId);
    Task<Animal> GetAnimalById(int id);
    
}
