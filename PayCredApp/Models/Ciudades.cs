using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class Ciudades
	{
		[Key]
		public int IdCiudad { get; set; }
		[Required(ErrorMessage = "Nombres es requerido")]
		public string Nombres { get; set; } = string.Empty;
		public virtual ICollection<Clientes> Clientes { get; set; } = new HashSet<Clientes>();
	}
}
