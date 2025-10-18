using NotificacionesServicio.Interfaces;
using System.Net;
using System.Net.Mail;

namespace NotificacionesServicio
{
    public class NotificacionServicio : INotificacionServicio
    {
        public async Task EnviarPorCorreoAsync()
        {
            var from = "notificacion@vmartinez84.xyz";
            var to = "ahal_tocob@hotmail.com";//Su correo
            var subject = "Prueba desde C#";
            var body = "Hola, es un correo de prueba enviado con C#.";

            try
            {
                using (var client = new SmtpClient("vmartinez84.xyz", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(from, "1s31f?G6e");

                    var mail = new MailMessage(from, to, subject, body)
                    {
                        IsBodyHtml = false
                    };

                    await client.SendMailAsync(mail);
                    Console.WriteLine("Correo enviado");
                    Console.WriteLine("Correo enviado");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
