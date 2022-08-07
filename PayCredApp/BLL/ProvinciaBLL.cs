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
