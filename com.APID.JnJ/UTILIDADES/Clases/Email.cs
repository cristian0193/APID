using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace UTILIDADES.Clases
{
    public class Email
    {
        #region Atributos

        private string toUser = "";
        private string subject = "";
        private string body = "";

        #endregion

        #region Constructor

        public Email(string toUser,string subject,string body)
        {
            this.toUser = toUser;
            this.subject = subject;
            this.body = body;
        }

        #endregion

        #region Metodos

        public int SentEmail()
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(this.toUser));
            msg.Subject = this.subject;
            msg.Body = this.body;
            msg.From = new MailAddress("RA-CONCO-IT-Soporte@its.jnj.com");
           
            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.Port = 25;
            
            try
            {
                clienteSmtp.Send(msg);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadLine();
                return 2;
            }
        }

        #endregion
    }
}
