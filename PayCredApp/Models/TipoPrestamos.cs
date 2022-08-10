using System.ComponentModel.DataAnnotations;

namespace PayCredApp.Models
{
    public class TipoPrestamos
    {
        [Key]
        public int IdTipoPrestamo { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int DiaGracias { get; set; } = 0;

        public virtual ICollection<ePrestamos> ePrestamos { get; set; } = new HashSet<ePrestamos>();
    }
}
