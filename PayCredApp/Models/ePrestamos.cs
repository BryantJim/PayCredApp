using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
    public class ePrestamos
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; } = 1;
        public virtual Clientes? Clientes { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public decimal Capital { get; set; } = 0;
        public decimal Interes { get; set; } = 0;
        public int Cuotas { get; set; } = 0;
        public decimal TasaInteres { get; set; } = 0;
        public decimal TasaMora { get; set; } = 0;
        public int IdTipoPrestamo { get; set; } = 2;
        public virtual TipoPrestamos? TipoPrestamos { get; set; }
        public DateTime FechaVencimiento { get; set; } = DateTime.Now;
        public decimal BceCapital { get; set; } = 0;
        public decimal BceInteres { get; set; } = 0;
        public string Observaciones { get; set; } = string.Empty;
        public bool Saldo { get; set; } = false;
		public bool EsNulo { get; set; } = false;
        public int CreadoPor { get; set; } = 1;
        public virtual Usuarios? Usuarios { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int ModificadoPor { get; set; } = 1;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public virtual ICollection<dPrestamos> dPrestamos { get; set; } = new HashSet<dPrestamos>();
        public virtual ICollection<eCobros> eCobros { get; set; } = new HashSet<eCobros>();
    }
}
