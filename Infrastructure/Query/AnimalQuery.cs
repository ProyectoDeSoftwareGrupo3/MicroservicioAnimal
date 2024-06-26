﻿using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class AnimalQuery : IAnimalQuery
    {
        private readonly AnimalDbContext _context;
        private readonly IUserService _userService;

        public AnimalQuery(AnimalDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Animal> GetAnimalById(int id)
        {
            try
            {
                var result = await _context.Animales.AsNoTracking()
                    .Include(a => a.Raza)
                    .Include(a => a.Media)
                    .Include(a => a.Raza.Tipo)
                    .FirstOrDefaultAsync(a => a.Id == id);
                return result;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<List<Animal>> GetListAnimal(string? nombre, decimal? peso, int? edad, bool? genero, int? tipoId, int? razaId, string? localidad)
        {
            try
            {
                var query = _context.Animales
                    .Include(a => a.Raza)
                    .Include(a => a.Media)
                    .Include(a => a.Raza.Tipo)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(nombre))
                {
                    query = query.Where(p => p.Nombre.Contains(nombre));
                }
                if (peso != null)
                {
                    query = query.Where(a => a.Peso == peso);
                }
                if (edad != null)
                {
                    query = query.Where(a => a.Edad == edad);
                }
                if (genero != null)
                {
                    query = query.Where(a => a.Genero == genero);
                }
                if (tipoId != null)
                {
                    query = query.Where(a => a.Raza.TipoId == tipoId);
                }
                if (razaId != null)
                {
                    query = query.Where(a => a.Raza.Id == razaId);
                }
                if (!string.IsNullOrEmpty(localidad))
                {
                    var users = await _userService.GetUsers();
                    var userIds = users.Where(u => u.City.Contains(localidad)).Select(u => u.Id).ToList();
                    query = query.Where(a => userIds.Contains(a.UsuarioId));
                }

                return await query.ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<List<Animal>> GetListAnimalByUserId(string userId)
        {
            try
            {
                var query = _context.Animales
                    .Include(a => a.Raza)
                    .Include(a => a.Media)
                    .Include(a => a.Raza.Tipo)
                    .AsQueryable();
                query = query.Where(a => a.UsuarioId == userId.ToUpper());
                return await query.ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
