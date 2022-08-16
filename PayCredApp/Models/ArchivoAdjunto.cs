namespace PayCredApp.Models
{
    public class ArchivoAdjunto
    {
        public ArchivoAdjunto() { }
        public ArchivoAdjunto(string contentType, string base64Data, string nombre)
        {
            ContentType = contentType;
            Base64Data = base64Data;
            Nombre = nombre;
        }

        public string ContentType { get; set; }
        public string Base64Data { get; set; }
        public string Nombre { get; set; }
    }
}
