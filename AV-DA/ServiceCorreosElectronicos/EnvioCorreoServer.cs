using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace AV.DA.ServiceCorreosElectronicos
{
    public abstract class EnvioCorreoServer
    {
        private SmtpClient smtpClient;
        protected string senderCorreo { get; set; } 
        protected string contraseña { get; set; }
        protected string host { get; set; }
        protected int puerto { get; set; }
        protected bool ssl { get; set; }

        protected void inicializarSmtpCliente()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderCorreo, contraseña);
            smtpClient.Host = host;
            smtpClient.Port = puerto;
            smtpClient.EnableSsl = ssl;
        }

        public void enviarCorreo(string asunto, string cuerpo, List<string> destinatarios)
        {
            var mensajeCorreo = new MailMessage();
            try
            {
                mensajeCorreo.From = new MailAddress(senderCorreo);
                foreach (string correo in destinatarios)
                {
                    mensajeCorreo.To.Add(correo);
                }
                mensajeCorreo.Subject = asunto;
                mensajeCorreo.Body = cuerpo;
                mensajeCorreo.Priority = MailPriority.Normal;
                smtpClient.Send(mensajeCorreo);
            
            }
            catch (Exception ex) { }
            finally
            {
                mensajeCorreo.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
