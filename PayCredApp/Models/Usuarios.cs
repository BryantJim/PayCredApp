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
		public Roles Roles { get; set; } = new Roles();
		public bool EsNulo { get; set; } = false;

		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();
	}
}
