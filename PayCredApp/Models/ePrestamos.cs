using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
    public class ePrestamos
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdCliente { get; set; }
        public virtual Clientes? Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public int Cuotas { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal TasaMora { get; set; }
        public int IdTipoPrestamo { get; set; }
        public virtual TipoPrestamos? TipoPrestamos { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal BceCapital { get; set; }
        public decimal BceInteres { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public bool EsNulo { get; set; }
        public int CreadoPor { get; set; } = 1;
        public virtual Usuarios? Usuarios { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int ModificadoPor { get; set; } = 1;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public virtual ICollection<dPrestamos> dPrestamos { get; set; } = new HashSet<dPrestamos>();
    }
}
