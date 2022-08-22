using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PayCredApp.Configuraciones.Validaciones
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    sealed public class ValidacionTelefono : ValidationAttribute
	{
        public ValidacionTelefono(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                string expresion;
                expresion = @"^(\+1)?\s?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})(\s?(x|([Ee]xt[.:]?\s?))[0-9]{4})?$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            return false;
        }
    }
}
