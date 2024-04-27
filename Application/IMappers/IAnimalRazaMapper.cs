﻿using Application.Response;
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
        Task<GetAnimalRazaResponse> CreateAnimalRazaResponse(AnimalRaza raza);
    }
}
