using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
	public class ProvinciaBLL
    {
        private readonly Contexto _context;

        public ProvinciaBLL(Contexto context)
        {
            _context = context;
        }
        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.Provincias.AnyAsync(x => x.IdProvincia == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(Provincias provincia)
        {
            if (await Existe(provincia.IdProvincia))
                return await Modificar(provincia);
            else
                return await Insertar(provincia);

        }

        private async Task<bool> Insertar(Provincias provincia)
        {
            bool guardado = false;
            try
            {
                await _context.Provincias.AddAsync(provincia);
                guardado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        private async Task<bool> Modificar(Provincias provincia)
        {
            bool modificado = false;
            try
            {
                _context.Entry(provincia).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<List<Provincias>> GetList(Expression<Func<Provincias, bool>> expression)
        {
            List<Provincias> Lista = new List<Provincias>();
            try
            {
                Lista = await _context.Provincias.Where(expression).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
        public async Task<Provincias> Buscar(int id)
        {
            Provincias provincia = new Provincias();

            try
            {
                var provinciaEncontrado = await _context.Provincias.FindAsync(id);

                if (provinciaEncontrado != null)
                    provincia = provinciaEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return provincia;
        }
    }
}
