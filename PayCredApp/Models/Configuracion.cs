using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace PayCredApp.Models
{
    public class Configuracion
    {
        [Key]
        public int IdConfiguracion { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
