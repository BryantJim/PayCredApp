using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PayCredApp.Configuraciones.Validaciones;

namespace PayCredApp.Models
{
	public class Clientes
	{
		[Key]
		public int IdCliente { get; set; }
		[Required(ErrorMessage = "Nombre es requerido")]
		public string Nombres { get; set; } = string.Empty;
		[Required(ErrorMessage = "Apellido es requerido")]
		public string Apellidos { get; set; } = string.Empty;
		[Required(ErrorMessage = "Fecha Nacimiento es requerido")]
		public DateTime FechaNacimiento { get; set; } = DateTime.Now.AddYears(-18);
		[ValidacionCedula("Cédula no es válida")]
		[Required(ErrorMessage = "Cédula es requerido")]
		public string Cedula { get; set; } = string.Empty;
		[ValidacionTelefono("Teléfono no es válido")]
		[Required(ErrorMessage = "Teléfono es requerido")]
		public string Telefono { get; set; } = string.Empty;
		[ValidacionTelefono("Celular no es válido")]
		[Required(ErrorMessage = "Celular es requerido")]
		public string Celular { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		[Required(ErrorMessage = "Ciudad es requerido")]
		public int IdCiudad { get; set; } = 1;
		public virtual Ciudades? Ciudades { get; set; }
		[Required(ErrorMessage = "Provincia es requerido")]
		public int IdProvincia { get; set; } = 1;
		public virtual Provincias? Provincias { get; set; }
		[ValidacionEmail("Correo no es válido")]
		[Required(ErrorMessage ="Correo es requerido")]
		public string Correo { get; set; } = string.Empty;
		public bool Activo { get; set; } = true;
		public int CreadoPor { get; set; } = 1;
		public virtual Usuarios? Usuarios { get; set; }
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public int ModificadoPor { get; set; } = 1;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;


		public virtual ICollection<ePrestamos> ePrestamos { get; set; } = new HashSet<ePrestamos>();
		public virtual ICollection<eCobros> eCobros { get; set; } = new HashSet<eCobros>();
	}
}
