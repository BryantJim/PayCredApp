using System.Security.Claims;

namespace PayCredApp.Configuraciones
{
    public static class Extensiones
    {
		public static string GetUserID(this ClaimsPrincipal principal)
		{
			if (principal == null)
				throw new ArgumentNullException(nameof(principal));

			return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}
	}
}
