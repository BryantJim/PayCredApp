﻿using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
    public class ClienteBLL
    {
        private readonly Contexto _context;

        public ClienteBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.Clientes.AnyAsync(x => x.IdCliente == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            if (await Existe(cliente.IdCliente))
                return await Modificar(cliente);
            else
                return await Insertar(cliente);

        }

        public async Task<bool> Insertar(Clientes cliente)
        {
            bool guardado = false;
            try
            {
                await _context.Clientes.AddAsync(cliente);
                guardado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        public async Task<bool> Modificar(Clientes cliente)
        {
            bool modificado = false;
            try
            {
                _context.Entry(cliente).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<Clientes> Buscar(int id)
        {
            Clientes cliente = new Clientes();

            try
            {
                var clienteEncontrado = await _context.Clientes.FindAsync(id);

                if (clienteEncontrado != null)
                    cliente = clienteEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool eliminado = false;

            try
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente != null)
                {
                    cliente.Activo = false;
                    _context.Entry(cliente).State = EntityState.Modified;
                    eliminado = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        public async Task<List<Clientes>> GetList(Expression<Func<Clientes, bool>> cliente)
        {
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = await _context.Clientes.Where(cliente).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
