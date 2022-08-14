using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class eCobros
	{
		[Key]
		public int IdCobro { get; set; }
		public int IdCliente { get; set; }
		public virtual Clientes? Clientes { get; set; }
		public int IdPrestamo { get; set; }
		public virtual ePrestamos? ePrestamos { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Descuento { get; set; }
		public decimal Monto { get; set; }
		public decimal CapitalCobrado { get; set; }
		public decimal InteresCobrado { get; set; }
		public decimal MoraCobrada { get; set; }
		public bool EsNulo { get; set; }
		public int CreadoPor { get; set; } = 1;
		public virtual Usuarios? Usuarios { get; set; }
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public int ModificadoPor { get; set; } = 1;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;

		public virtual ICollection<dCobros> dCobros { get; set; } = new HashSet<dCobros>();
	}
}
