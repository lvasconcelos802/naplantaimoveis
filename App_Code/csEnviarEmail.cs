using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace quartoesuite
{
    public class csEnviarEmail
    {
        public static bool EnviaMensagem(string remetenteNome, string remetenteEmail, string destinatarioNome, string destinatarioEmail, string assunto, string mensagem)
        {

            try
            {

                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress("newsletter@naplantaimoveis.com.br", remetenteNome);
                    emailMessage.To.Add(new MailAddress(destinatarioEmail, destinatarioNome));
                    //emailMessage.ReplyTo = "comercial@naplantaimoveis.com.br"; 
                    emailMessage.Subject = assunto;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = mensagem;
                    emailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient MailClient = new SmtpClient("mail.naplantaimoveis.com.br", 587))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.Credentials = new System.Net.NetworkCredential("newsletter@naplantaimoveis.com.br", "elefante2020!");
                        MailClient.Send(emailMessage);
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }           

        }
    }
}