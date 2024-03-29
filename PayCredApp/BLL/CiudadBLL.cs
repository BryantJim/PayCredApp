﻿using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
	public class CiudadBLL
    {
        private readonly Contexto _context;

        public CiudadBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.Ciudades.AnyAsync(x => x.IdCiudad == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(Ciudades ciudad)
        {
            if (await Existe(ciudad.IdCiudad))
                return await Modificar(ciudad);
            else
                return await Insertar(ciudad);

        }

        private async Task<bool> Insertar(Ciudades ciudad)
        {
            bool guardado = false;
            try
            {
                await _context.Ciudades.AddAsync(ciudad);
                guardado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        private async Task<bool> Modificar(Ciudades ciudad)
        {
            bool modificado = false;
            try
            {
                _context.Entry(ciudad).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<List<Ciudades>> GetList(Expression<Func<Ciudades, bool>> ciudad)
        {
            List<Ciudades> Lista = new List<Ciudades>();
            try
            {
                Lista = await _context.Ciudades.Where(ciudad).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public async Task<Ciudades> Buscar(int id)
        {
            Ciudades ciudad = new Ciudades();

            try
            {
                var ciudadEncontrado = await _context.Ciudades.FindAsync(id);

                if (ciudadEncontrado != null)
                    ciudad = ciudadEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return ciudad;
        }
    }
}
