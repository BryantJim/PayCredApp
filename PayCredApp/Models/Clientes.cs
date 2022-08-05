using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayCredApp.Models
{
	public class Clientes
	{
		[Key]
		public int IdCliente { get; set; }
		public string Nombres { get; set; } = string.Empty;
		public string Apellidos { get; set; } = string.Empty;
		public DateTime FechaNacimiento { get; set; } = DateTime.Now;
		public string Cedula { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string Celular { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public int IdCiudad { get; set; } = 1;
		public virtual Ciudades Ciudades { get; set; } = new Ciudades();
		public int IdProvincia { get; set; } = 1;
		public virtual Provincias Provincias { get; set; } = new Provincias();
		public bool Activo { get; set; } = true;
		public int CreadoPor { get; set; } = 1;
		public virtual Usuarios Usuarios { get; set; } = new Usuarios();
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public int ModificadoPor { get; set; } = 1;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;
	}
}
