using PayCredApp.Data;
using PayCredApp.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PayCredApp.Configuraciones;

namespace PayCredApp.BLL
{
    public class ConfiguracionBLL
    {
        private readonly Contexto _context;

        public ConfiguracionBLL(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Modificar(Configuracion configuracion)
        {
            bool modificado = false;
            try
            {
                configuracion.Clave = Seguridad.Encrypt(configuracion.Clave);
                _context.Entry(configuracion).State = EntityState.Modified;
                modificado = await _context.SaveChangesAsync() > 0;
                _context.ChangeTracker.Clear();
            }
            catch (Exception)
            {
                throw;
            }

            return modificado;
        }

        public async Task<Configuracion> Buscar(int id)
        {
            Configuracion configuracion = new Configuracion();

            try
            {
                var ConfiguracionEncontrada = await _context.Configuraciones.Where(x => x.IdConfiguracion == id)
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();


                if (ConfiguracionEncontrada != null)
                {
                    configuracion = ConfiguracionEncontrada;
                    configuracion.Clave = Seguridad.Descrypt(ConfiguracionEncontrada.Clave);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return configuracion;
        }
    }
}