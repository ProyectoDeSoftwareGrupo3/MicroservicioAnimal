﻿using Application.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class FotoMapper : IFotoMapper
    {
        public Task<List<GetFotoReponse>> CreateListFotoResponse(List<Foto> fotos)
        {
            List<GetFotoReponse> fotoResponses = new List<GetFotoReponse>();

            foreach (var foto in fotos)
            {
                fotoResponses.Add(new GetFotoReponse
                {
                    url = foto.url,
                });
            }
            
            return Task.FromResult(fotoResponses);
        }
    }
}