using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;
using PayCredApp.Configuraciones;
using System.Net;
using System.ComponentModel;
using System.Text;
using System.Net.Mime;
using PayCredApp.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace PayCredApp.Configuraciones
{
	public static class Utilitarios
	{
        /*CONFIGURACIÓN SMTP:
    ---------------------------------------------------------
    * OUTLOOK -->
    servidor SMTP: smtp-mail.outlook.com
    puerto: 587
    ---------------------------------------------------------
      * GMAIL -->
      servidor SMTP: smtp.gmail.com
    * puerto: 465 (SSL); 587 (TLS)
    ---------------------------------------------------------
      * YAHOO! -->
      servidor SMTP: smtp.mail.yahoo.com
      puerto: 25 ó 265
       */

        public static string[] microsoftDomains = new string[] { "@outlook", "@live", "@hotmail" };
        static int[] microsoftPorts = new int[] { 587 };

        public static string[] googleDomains = new string[] { "@gmail" };
        public static int[] googlePorts = new int[] { 587, 487 };

        public static string[] yahooDomains = new string[] { "@yahoo" };
        public static int[] yahooPorts = new int[] { 25, 265 };

        private static char[] separadores = new char[] { ',', '|' };

        public static InfoCorreo InfoCorreo { get; set; } = new();

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

        public static bool IsValidCedula(this string Cedula)
        {
            return Regex.IsMatch(Cedula ?? "", @"^\(?([0-9]{3})\)?[-]?([0-9]{7})[-]?([0-9]{1})$");
        }

        public static bool IsValidTelefono(this string Telefono)
        {
            return Regex.IsMatch(Telefono ?? "", @"^(\+1)?\s?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})(\s?(x|([Ee]xt[.:]?\s?))[0-9]{4})?$");
        }

        public static (string host, int port) ObtenerHost(string correo)
        {
            if (correo.Contains(microsoftDomains, ignoreCase: true))
            {
                return ("smtp-mail.outlook.com", microsoftPorts[0]);

            }
            else if (correo.Contains(googleDomains, ignoreCase: true))
            {
                return ("smtp.gmail.com", googlePorts[0]);

            }
            else if (correo.Contains(yahooDomains, ignoreCase: true))
            {
                return ("smtp.mail.yahoo.com", yahooPorts[0]);
            }

            throw new InvalidOperationException("No hay un host configurado para este correo");
        }

        public static SmtpClient ConfigurarSmtpClient()
        {
            (string host, int port) = ObtenerHost(InfoCorreo.CorreoEmisor);
            var smtpClient = new SmtpClient(host, port);

            smtpClient.Credentials = new NetworkCredential(InfoCorreo.CorreoEmisor, InfoCorreo.ClaveEmisor);
            smtpClient.EnableSsl = true;

            return smtpClient;
        }
        public static void AgregarReceptores(string correosAgregar, MailAddressCollection correosDestino)
        {

            string[] receptores = correosAgregar.Split(separadores);
            foreach (string receptor in receptores)
            {
                if (receptor.IsValidEmail())
                {
                    correosDestino.Add(receptor.Trim());
                }
                else
                {
                    throw new Exception($"El correo {receptor} es invalido");
                }
            }
        }

        public static void AgregarReceptoresCopias(string correosAgregar, MailMessage mail, TipoCopias tipo)
        {
            if (string.IsNullOrWhiteSpace(correosAgregar))
            {
                return;
            }

            string[] receptores = correosAgregar.Split(separadores);
            foreach (string receptor in receptores)
            {
                if (receptor.IsValidEmail())
                {
                    if (tipo == TipoCopias.CC)
                    {
                        mail.CC.Add(receptor.Trim());
                    }
                    else
                    {
                        mail.Bcc.Add(receptor.Trim());
                    }
                }
                else
                {
                    throw new Exception($"El correo {receptor} es invalido");
                }
            }
        }
        public static void AgregarArchivosAdjuntos(MailMessage mail)
        {
            foreach (var adjunto in InfoCorreo.ArchivosAdjuntos)
            {
                mail.Attachments.Add(adjunto);
            }
        }

        public static MailMessage GenerarCorreo()
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(InfoCorreo.CorreoEmisor, InfoCorreo.NombreEmisor, System.Text.Encoding.UTF8);
            AgregarReceptores(InfoCorreo.CorreoReceptores, mail.To);
            AgregarReceptoresCopias(InfoCorreo.CorreoReceptoresCopias, mail, InfoCorreo.TipoCopias);

            mail.Subject = InfoCorreo.Asunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.Body = InfoCorreo.CuerpoCorreo;
            mail.IsBodyHtml = InfoCorreo.EsHtml;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            AgregarArchivosAdjuntos(mail);

            return mail;
        }

        public static async Task ActualizarArchivos(InputFileChangeEventArgs args)
        {
            InfoCorreo.ArchivosAdjuntos = new();

            var archivos = args.GetMultipleFiles(int.MaxValue);
            foreach (var archivo in archivos)
            {
                try
                {
                    using (var stream = archivo.OpenReadStream(long.MaxValue))
                    {
                        string stringContent;

                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            stringContent = await reader.ReadToEndAsync();
                        }

                        InfoCorreo.ArchivosAdjuntos.Add(Attachment.CreateAttachmentFromString(stringContent, new ContentType(archivo.ContentType) { Name = archivo.Name }));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        //public static async Task EnviarCorreo()
        //{
        //    try
        //    {
        //        await Task.Run(() =>
        //        {
        //            var smtpClient = ConfigurarSmtpClient();
        //            var mensaje = GenerarCorreo();

        //            smtpClient.Send(mensaje);
        //            toastService.ShowSuccess("Correo enviado!");

        //        });

        //    }
        //    catch (Exception e)
        //    {
        //        toastService.ShowError(e.Message);
        //    }
        //}
    }
}