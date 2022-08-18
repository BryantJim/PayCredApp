using System.Globalization;
using System.Text.RegularExpressions;

namespace PayCredApp.Configuraciones
{
	public static class Utilitarios
	{
		public static decimal ConverToN2(decimal valor)
		{
            return Convert.ToDecimal(valor.ToString("N2"));
		}

        public static string ToStringFromArray(this object[] array, string separator = ", ")
        {
            string content = "";
            foreach (var item in array)
            {
                content += content == "" ? item.ToString() : separator + item.ToString();
            }
            return content;
        }

        public static bool Contains(this string text, string[] keywods, bool ignoreCase = false)
        {
            bool found = false;
            text = ignoreCase ? text.ToLower() : text;

            foreach (var keyword in keywods)
            {
                var keywordTemp = ignoreCase ? keyword.ToLower() : keyword;
                if (text.Contains(keywordTemp.Trim()))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static bool IsValidEmail(this string email)
        {
            return Regex.IsMatch(email ?? "", @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}