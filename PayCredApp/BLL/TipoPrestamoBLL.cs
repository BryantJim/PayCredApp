using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
    public class TipoPrestamoBLL
    {
        private readonly Contexto _context;

        public TipoPrestamoBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.TipoPrestamos.AnyAsync(x => x.IdTipoPrestamo == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(TipoPrestamos tipoPrestamos)
        {
            if (await Existe(tipoPrestamos.IdTipoPrestamo))
                return await Modificar(tipoPrestamos);
            else
                return await Insertar(tipoPrestamos);

        }

        private async Task<bool> Insertar(TipoPrestamos tipoPrestamos)
        {
            bool guardado = false;
            try
            {
                await _context.TipoPrestamos.AddAsync(tipoPrestamos);
                guardado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        private async Task<bool> Modificar(TipoPrestamos tipoPrestamos)
        {
            bool modificado = false;
            try
            {
                _context.Entry(tipoPrestamos).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<List<TipoPrestamos>> GetList(Expression<Func<TipoPrestamos, bool>> expression)
        {
            List<TipoPrestamos> Lista = new List<TipoPrestamos>();
            try
            {
                Lista = await _context.TipoPrestamos.Where(expression).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public async Task<TipoPrestamos> Buscar(int id)
        {
            TipoPrestamos tipoPrestamos = new TipoPrestamos();

            try
            {
                var tipoPrestamoEncontrado = await _context.TipoPrestamos.FindAsync(id);

                if (tipoPrestamoEncontrado != null)
                    tipoPrestamos = tipoPrestamoEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return tipoPrestamos;
        }
    }
}
