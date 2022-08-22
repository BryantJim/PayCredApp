using Microsoft.EntityFrameworkCore;
using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq.Expressions;

namespace PayCredApp.BLL
{
    public class eCobroBLL
    {
        private readonly Contexto _context;

        public eCobroBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = false;
            try
            {
                existe = await _context.eCobros.AnyAsync(x => x.IdCobro == id);
            }
            catch (Exception)
            {
                throw;
            }

            return existe;
        }

        public async Task<bool> Guardar(eCobros eCobro)
        {
            if (await Existe(eCobro.IdCobro))
                return await Modificar(eCobro);
            else
                return await Insertar(eCobro);

        }

        private async Task<bool> Insertar(eCobros eCobro)
        {
            bool guardado = false;

            try
            {
                _context.Database.BeginTransaction();

                foreach (var item in eCobro.dCobros)
                {
                    await _context.Database.ExecuteSqlRawAsync($"UPDATE dPrestamos SET BceCapital -= " +
                        $"{item.CapitalCobrado},BceInteres -= {item.InteresCobrado} WHERE IdPrestamo = {item.IdPrestamo} AND NoCuota = {item.NoCuota}");
                }

                _context.Database.ExecuteSqlRaw($"UPDATE ePrestamos SET BceCapital -= {eCobro.CapitalCobrado}, BceInteres -= {eCobro.InteresCobrado} WHERE IdPrestamo = {eCobro.IdPrestamo}");

                eCobro.CreadoPor = eCobro.Usuarios.IdUsuario;
                eCobro.FechaCreacion = DateTime.Now;
                eCobro.ModificadoPor = eCobro.Usuarios.IdUsuario;
                eCobro.FechaModificacion = DateTime.Now;

                await _context.eCobros.AddAsync(eCobro);
                guardado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                throw;
            }

            _context.Database.CommitTransaction();
            return guardado;
        }

        private async Task<bool> Modificar(eCobros eCobro)
        {
            bool modificado = false;
            try
            {

                _context.Database.ExecuteSqlRaw($"DELETE FROM dCobros WHERE IdCobro = {eCobro.IdCobro}");

                foreach (var item in eCobro.dCobros)
                {
                    _context.Entry(item).State = EntityState.Added;
                }

                eCobro.ModificadoPor = eCobro.Usuarios.IdUsuario;
                eCobro.FechaModificacion = DateTime.Now;

                _context.Entry(eCobro).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<eCobros> Buscar(int id)
        {
            eCobros eCobro = new eCobros();

            try
            {
                var eCobroEncontrado = await _context.eCobros.Where(x => x.IdCobro == id)
                                                                .Include(x => x.Clientes)
                                                                .Include(x => x.ePrestamos)
                                                                .Include(x => x.dCobros)
                                                                .Include(x => x.Usuarios)
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();

                if (eCobroEncontrado != null)
                    eCobro = eCobroEncontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return eCobro;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool eliminado = false;
            _context.Database.BeginTransaction();
            
            try
            {
                var eCobro = await Buscar(id);

                if (eCobro != null)
                {

                    foreach (var item in eCobro.dCobros)
                    {
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE dPrestamos SET BceCapital += " +
                            $"{item.CapitalCobrado},BceInteres += {item.InteresCobrado} WHERE IdPrestamo = {item.IdPrestamo} AND NoCuota = {item.NoCuota}");
                    }

                    _context.Database.ExecuteSqlRaw($"UPDATE ePrestamos SET BceCapital += {eCobro.CapitalCobrado}, BceInteres += {eCobro.InteresCobrado} WHERE IdPrestamo = {eCobro.IdPrestamo}");

                    _context.Database.ExecuteSqlRaw($"DELETE FROM dCobros WHERE IdCobro = {eCobro.IdCobro}");

                    eCobro.EsNulo = true;
                    _context.Entry(eCobro).State = EntityState.Modified;
                    eliminado = await _context.SaveChangesAsync() > 0;
                    _context.ChangeTracker.Clear();
                }
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                throw;
            }

            _context.Database.CommitTransaction();
            return eliminado;
        }

        public async Task<List<eCobros>> GetList(Expression<Func<eCobros, bool>> expression)
        {
            List<eCobros> Lista = new List<eCobros>();
            try
            {
                Lista = await _context.eCobros.Where(expression).Where(x => x.EsNulo == false).Include(x => x.Clientes).Include(x => x.dCobros).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public async Task<bool> tieneCobros(int IdPrestamo)
		{
            List<eCobros> Lista = new List<eCobros>();
            bool tieneC = false;

            try
            {
                Lista = await _context.eCobros.Where(x => x.EsNulo == false && x.IdPrestamo == IdPrestamo).ToListAsync();

                if(Lista.Count == 0)
                    tieneC = false;  
                else
                    tieneC = true;
            }
            catch (Exception)
            {
                throw;
            }
            return tieneC;
        }
    }
}
