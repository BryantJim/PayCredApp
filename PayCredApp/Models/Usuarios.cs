using PayCredApp.Configuraciones.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCredApp.Models
{
	public class Usuarios
	{
		[Key]
		public int IdUsuario { get; set; }
		[Required(ErrorMessage = "Nombres es requerido")]
		public string Nombres { get; set; } = string.Empty;
		[Required(ErrorMessage = "Nombre de Usuario es requerido")]
		public string NombreUsuario { get; set; } = string.Empty;
		[Required(ErrorMessage = "Contraseña es requerida")]
		public string Contrasena { get; set; } = string.Empty;
		[ValidacionEmail("Correo no es válido")]
		[Required(ErrorMessage = "Correo es requerido")]
		public string Correo { get; set; } = string.Empty;
		public int IdRol { get; set; } = 1;
		public Roles? Roles { get; set; }
		public bool EsNulo { get; set; } = false;
		public string Token { get; set; } = "";
        public DateTime FechaExpiracion { get; set; } = DateTime.Now;

        public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();
		public virtual ICollection<ePrestamos> ePrestamos { get; set; } = new HashSet<ePrestamos>();
		public virtual ICollection<eCobros> eCobros { get; set; } = new HashSet<eCobros>();
	}
}
