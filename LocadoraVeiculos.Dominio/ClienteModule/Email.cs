using LocadoraVeiculos.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Email
    {


        public Email()
        {
            
        }

        public void enviaEmail(Locacao locacao)
        {
            string email = locacao.Cliente.Email;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("runtimeterror73@gmail.com", "Runtimeterror");


                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(email);

                   //para
                    mail.To.Add(new System.Net.Mail.MailAddress("Para: " + locacao.Cliente.Email));

                   
                    //if (!string.IsNullOrWhiteSpace(textBoxCC.Text))
                    //    mail.CC.Add(new System.Net.Mail.MailAddress(textBoxCC.Text));
                    //if (!string.IsNullOrWhiteSpace(textBoxCCo.Text))
                    //    mail.Bcc.Add(new System.Net.Mail.MailAddress(textBoxCCo.Text));


                    mail.Subject = "O PDF";
                    mail.Body = "TESTE TESTE TESTE TESTE TESTE TESTE \n TESTE TESTE TESTE TESTE TESTE TESTE \n TESTE TESTE TESTE TESTE TESTE TESTE \n";

                    smtp.Send(mail);
                }

               
            }
        }
        
    }
}
