using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
	public class dCobros
	{
		[Key]
		public int Id { get; set; }
		public int IdCobro { get; set; }
		public virtual eCobros? eCobros { get; set; }
		public int IdPrestamo { get; set; }
		public int NoCuota { get; set; }
		public decimal CapitalCobrado { get; set; }
		public decimal InteresCobrado { get; set; }
		public decimal MoraCobrada { get; set; }
	}
}
