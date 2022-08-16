using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace PayCredApp.Models
{
    public class InfoCorreo
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        public string CorreoEmisor { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string ClaveEmisor { get; set; }
        public string NombreEmisor { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Asunto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string CorreoReceptores { get; set; }
        public string CorreoReceptoresCopias { get; set; }
        public TipoCopias TipoCopias { get; set; } = TipoCopias.CC;
        [Required(ErrorMessage = "Este campo es requerido")]
        public string CuerpoCorreo { get; set; }
        public bool EsHtml { get; set; }
        public List<Attachment> ArchivosAdjuntos { get; set; } = new();
    }
}
