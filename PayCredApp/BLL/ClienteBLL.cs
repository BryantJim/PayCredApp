using Microsoft.EntityFrameworkCore;
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

        private async Task<bool> Insertar(Clientes cliente)
        {
            bool guardado = false;
            try
            {
                cliente.CreadoPor = cliente.Usuarios.IdUsuario;
                cliente.FechaCreacion = DateTime.Now;
                cliente.ModificadoPor = cliente.Usuarios.IdUsuario;
                cliente.FechaModificacion = DateTime.Now;

                await _context.Clientes.AddAsync(cliente);
                guardado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                throw;
            }

            return guardado;
        }

        private async Task<bool> Modificar(Clientes cliente)
        {
            bool modificado = false;
            try
            {
                cliente.ModificadoPor = cliente.Usuarios.IdUsuario;
                cliente.FechaModificacion = DateTime.Now;

                _context.Entry(cliente).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
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
                var clienteEncontrado = await _context.Clientes.Where(x => x.IdCliente == id)
                                                                .Include(x => x.Ciudades)
                                                                .Include(x => x.Provincias)
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();

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
                var cliente = await Buscar(id);

                if (cliente != null)
                {
                    cliente.Activo = false;
                    _context.Entry(cliente).State = EntityState.Modified;
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

        public async Task<List<Clientes>> GetList(Expression<Func<Clientes, bool>> expression)
        {
            List<Clientes> Lista = new List<Clientes>();
            try
            {
                Lista = await _context.Clientes.Where(expression).Where(x => x.Activo == true).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
