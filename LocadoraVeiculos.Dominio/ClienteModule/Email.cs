﻿using LocadoraVeiculos.Dominio.LocacaoModule;
using System.Net;
using System.Net.Mail;

namespace LocadoraVeiculos.Dominio.ClienteModule
{
    public class Email
    {
        public async void EnviarEmailAsync(Locacao locacao, string nomeArquivo)
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

                    mail.Subject = "Locadora Rech: Devolução realizada com sucesso";

                    string corpoEmail = $"<h2><strong>Olá {locacao.Cliente.Nome}!</strong></h2>" +
                        $"<br/><h3>Houve uma locação de veículo recentemente fechada em seu nome." +
                        $"<br/>Segue em anexo o recibo contendo os dados da locação.</h3>" +
                        $"<br/><br/>Agradecemos a preferência, volte sempre!" +
                        $"<br/><i>Locadora Rech</i>";

                    mail.Body = corpoEmail;

                    mail.IsBodyHtml = true;

                    if (nomeArquivo != null)
                        mail.Attachments.Add(new Attachment(nomeArquivo));

                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
