namespace PayCredApp.Authentication
{
    public class UserSession
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public DateTime Expiracion { get; set; } = DateTime.UtcNow;
    }
}
