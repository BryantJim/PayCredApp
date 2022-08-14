using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCredApp.Models
{
	public class Usuarios
	{
		[Key]
		public int IdUsuario { get; set; }
		public string Nombres { get; set; } = string.Empty;
		public string NombreUsuario { get; set; } = string.Empty;
		public string Contrasena { get; set; } = string.Empty;
		public string Correo { get; set; } = string.Empty;
		public int IdRol { get; set; } = 1;
		public Roles? Roles { get; set; }
		public bool EsNulo { get; set; } = false;

		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();
		public virtual ICollection<ePrestamos> ePrestamos { get; set; } = new HashSet<ePrestamos>();
		public virtual ICollection<eCobros> eCobros { get; set; } = new HashSet<eCobros>();
	}
}
