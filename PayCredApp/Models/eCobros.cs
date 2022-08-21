using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class eCobros
	{
		[Key]
		public int IdCobro { get; set; }
		public int IdCliente { get; set; } = 0;
		public virtual Clientes? Clientes { get; set; }
		public int IdPrestamo { get; set; } = 0;
		public virtual ePrestamos? ePrestamos { get; set; }
		public DateTime Fecha { get; set; }	 = DateTime.Now;
		public decimal Descuento { get; set; } = 0;
		public decimal Monto { get; set; } = 0;
		public decimal CapitalCobrado { get; set; } = 0;
		public decimal InteresCobrado { get; set; } = 0;
		public decimal MoraCobrada { get; set; } = 0;
		public string Observaciones { get; set; } = string.Empty;
		public bool EsNulo { get; set; } = false;
		public int CreadoPor { get; set; } = 1;
		public virtual Usuarios? Usuarios { get; set; }
		public DateTime FechaCreacion { get; set; } = DateTime.Now;
		public int ModificadoPor { get; set; } = 1;
		public DateTime FechaModificacion { get; set; } = DateTime.Now;

		public virtual ICollection<dCobros> dCobros { get; set; } = new HashSet<dCobros>();
	}
}
