using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PayCredApp.Configuraciones.Validaciones
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    sealed public class ValidacionCedula : ValidationAttribute
    {

        public ValidacionCedula(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object? value)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                string expresion;
                expresion = @"^\d{3}[- ]?\d{7}[- ]?\d{1}$";
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
