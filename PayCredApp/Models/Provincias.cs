using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class Provincias
	{
		[Key]
		public int IdProvincia { get; set; }
		public string Nombres { get; set; } = string.Empty;
		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();
	}
}
