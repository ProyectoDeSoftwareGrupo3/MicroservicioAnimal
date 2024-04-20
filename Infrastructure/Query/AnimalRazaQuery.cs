using Application.Exceptions;
using Application.Interfaces.IAnimalRaza;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    return _context.AnimalesRazas.FirstOrDefault(ar => ar.Id == id);
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
                return await _context.AnimalesRazas.ToListAsync();
            }
            catch (Exception)
            {

                throw new Conflict("Hubo un error en la busqueda de la lista de razas");
            }
        }
    }
}
