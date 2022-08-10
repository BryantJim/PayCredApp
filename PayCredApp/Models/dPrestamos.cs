using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
    public class dPrestamos
    {
        [Key]
        public int Id { get; set; }
        public int IdPrestamo { get; set; }
        public virtual ePrestamos? ePrestamos { get; set; }
        public DateTime FechaCuota { get; set; }
        public int NoCuota { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal BceCapital { get; set; }
        public decimal BceInteres { get; set; }
    }
}
