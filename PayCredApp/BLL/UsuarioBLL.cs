﻿using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Configuraciones;
using System.Linq.Expressions;
using PayCredApp.Models;

namespace PayCredApp.BLL
{
	public class UsuarioBLL
    {
        private readonly Contexto _context;

        public UsuarioBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.Usuarios.AnyAsync(x => x.IdUsuario == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(Usuarios usuario)
        {
            if (await Existe(usuario.IdUsuario))
                return await Modificar(usuario);
            else
                return await Insertar(usuario);

        }

        public async Task<bool> Insertar(Usuarios usuario)
        {
            bool guardado = false;
            try
            {
                //string contra = usuario.Contrasena;
                //usuario.Contrasena = Seguridad.Encrypt(contra);
                //usuario.IdRol = 1;
                await _context.Usuarios.AddAsync(usuario);
                guardado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        public async Task<bool> Modificar(Usuarios usuario)
        {
            bool modificado = false;
            try
            {
                //string contra = usuario.Contrasena;
                //usuario.Contrasena = Seguridad.Encrypt(contra);
                _context.Entry(usuario).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<Usuarios> Buscar(int id)
        {
            Usuarios usuario = new Usuarios();

            try
            {
                var usuarioEncontrado = await _context.Usuarios.FindAsync(id);

                if (usuarioEncontrado != null)
                    usuario = usuarioEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool eliminado = false;

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                if (usuario != null)
                {
                    usuario.EsNulo = true;
                    _context.Entry(usuario).State = EntityState.Modified;
                    eliminado = await _context.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = await _context.Usuarios.Where(usuario).Where(x => x.EsNulo == false).Include(x => x.Roles).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public async Task<Usuarios> LogIn(string NombreUsuario, string Contrasena)
        {
            Usuarios usuario = new Usuarios();
            try
            {
                Contrasena = Seguridad.Encrypt(Contrasena);

                var user = await _context.Usuarios.Where(x =>
                    x.NombreUsuario == NombreUsuario && x.Contrasena == Contrasena && x.EsNulo == false).Include(x => x.Roles).FirstOrDefaultAsync();

                if (user != null)
                    usuario = user;

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public async Task<Usuarios> BuscarCorreo(string Correo)
        {
            Usuarios usuario = new Usuarios();

            try
            {
                var user = await _context.Usuarios.Where(x => x.Correo == Correo && x.EsNulo == false).FirstOrDefaultAsync();

                if (user != null)
                    usuario = user;

            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public async Task<bool> ValidarCorreo(string Correo)
        {
            bool paso = false;

            Usuarios usuario = new Usuarios();

            try
            {
                var user = await _context.Usuarios.Where(x => x.Correo == Correo && x.EsNulo == false).FirstOrDefaultAsync();

                if (user != null)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public async Task<bool> ValidarUsuario(string Usuario)
        {
            bool paso = false;

            Usuarios usuario = new Usuarios();

            try
            {
                var user = await _context.Usuarios.Where(x => x.NombreUsuario == Usuario && x.EsNulo == false).FirstOrDefaultAsync();

                if (user != null)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public async Task<List<Roles>> GetListRoles(Expression<Func<Roles, bool>> roles)
        {
            List<Roles> Lista = new List<Roles>();
            try
            {
                Lista = await _context.Roles.Where(roles).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
