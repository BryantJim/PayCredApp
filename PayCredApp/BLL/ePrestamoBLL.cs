using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
    public class ePrestamoBLL
    {
        private readonly Contexto _context;

        public ePrestamoBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.ePrestamos.AnyAsync(x => x.IdPrestamo == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(ePrestamos ePrestamo)
        {
            if (await Existe(ePrestamo.IdPrestamo))
                return await Modificar(ePrestamo);
            else
                return await Insertar(ePrestamo);

        }

        private async Task<bool> Insertar(ePrestamos ePrestamo)
        {
            bool guardado = false;
            try
            {
                ePrestamo.CreadoPor = ePrestamo.Usuarios.IdUsuario;
                ePrestamo.FechaCreacion = DateTime.Now;
                ePrestamo.ModificadoPor = ePrestamo.Usuarios.IdUsuario;
                ePrestamo.FechaModificacion = DateTime.Now;

                await _context.ePrestamos.AddAsync(ePrestamo);
                guardado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        private async Task<bool> Modificar(ePrestamos ePrestamo)
        {
            bool modificado = false;
            try
            {
                _context.Database.ExecuteSqlRaw($"DELETE FROM dPrestamos WHERE IdPrestamo = {ePrestamo.IdPrestamo}");

                foreach (var item in ePrestamo.dPrestamos)
                {
                    _context.Entry(item).State = EntityState.Added;
                }

                ePrestamo.ModificadoPor = ePrestamo.Usuarios.IdUsuario;
                ePrestamo.FechaModificacion = DateTime.Now;

                _context.Entry(ePrestamo).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<ePrestamos> Buscar(int id)
        {
            ePrestamos ePrestamo = new ePrestamos();

            try
            {
                var ePrestamoEncontrado = await _context.ePrestamos.Where(x => x.IdPrestamo == id)
                                                                .Include(x => x.Clientes)
                                                                .Include(x => x.TipoPrestamos)
                                                                .Include(x => x.dPrestamos)
                                                                .Include(x => x.Usuarios)
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();

                if (ePrestamoEncontrado != null)
                    ePrestamo = ePrestamoEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return ePrestamo;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool eliminado = false;

            try
            {
                var ePrestamo = await Buscar(id);

                if (ePrestamo != null)
                {
                    ePrestamo.EsNulo = false;
                    _context.Entry(ePrestamo).State = EntityState.Modified;
                    eliminado = await _context.SaveChangesAsync() > 0;
                    _context.ChangeTracker.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        public async Task<List<ePrestamos>> GetList(Expression<Func<ePrestamos, bool>> expression)
        {
            List<ePrestamos> Lista = new List<ePrestamos>();
            try
            {
                Lista = await _context.ePrestamos.Where(expression).Where(x => x.EsNulo == true).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
