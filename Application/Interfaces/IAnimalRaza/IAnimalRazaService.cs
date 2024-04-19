﻿using Application.Request;
using Application.Response;
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
    }
}
