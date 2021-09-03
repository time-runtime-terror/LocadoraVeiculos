using LocadoraVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Email
    {


        //private void ConfiguraServidor(Action<SmtpClient> action

        public void enviaEmail(Locacao locacao, string nomeArquivo)
        {
            string email = locacao.Cliente.Email;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("runtimeterror903@gmail.com", "Runtimeterror");
                

                using (MailMessage mail = new MailMessage())
                {

                    //de
                    mail.From = new MailAddress("runtimeterror903@gmail.com");

                   //para
                    mail.To.Add(new MailAddress(email));


                    mail.Subject = "O PDF";
                    mail.Body = "TESTE TESTE TESTE TESTE TESTE TESTE \n TESTE TESTE TESTE TESTE TESTE TESTE \n";

                    if (nomeArquivo != null)
                        mail.Attachments.Add(new Attachment(nomeArquivo));

                    smtp.Send(mail);
                }

               
            }
        }
        
    }
}
