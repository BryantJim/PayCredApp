using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class Roles
	{
		[Key]
		public int IdRol { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public ICollection<Usuarios> Usuarios { get; set; } = new HashSet<Usuarios>();
	}
}
