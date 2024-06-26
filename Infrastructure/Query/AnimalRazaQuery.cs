﻿using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Query
{
    public class AnimalRazaQuery:IAnimalRazaQuery
    {
        private readonly AnimalDbContext _context;


        public AnimalRazaQuery(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<AnimalRaza> GetAnimalRazaById(int id)
        {
            try
                {
                    return await _context.AnimalesRazas
                    .Include(ar =>ar.Tipo)
                    .FirstOrDefaultAsync(ar => ar.Id == id);
                }
            catch (DbException)
                {
                    throw new Conflict("Hubo un error en la busqueda de la raza");
                }

        }

        public async Task<List<AnimalRaza>> GetListAnimalRaza()
        {
            try
            {
                return await _context.AnimalesRazas
                    .Include(ar => ar.Tipo)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw new Conflict("Hubo un error en la busqueda de la lista de razas");
            }
        }
    }
}
