using Microsoft.EntityFrameworkCore;
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
