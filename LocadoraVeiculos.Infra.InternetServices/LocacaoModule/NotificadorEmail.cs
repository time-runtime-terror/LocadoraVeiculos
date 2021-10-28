using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using JsonFlatFileDataStore;

namespace LocadoraVeiculos.Infra.InternetServices.LocacaoModule
{
    public class NotificadorEmail : INotificadorEmail
    {
        private DataStore ArmazemDados { get; init; }

        public NotificadorEmail()
        {
            ArmazemDados = new DataStore("emailData.json");
        }
    
        public IEnumerable<Email> ObterEmailsAgendados()
        {
            return ArmazemDados.GetCollection<Email>().AsQueryable();
        }

        public bool EnviarEmailAgendado(Email email)
        {
            try
            {
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
                        mail.To.Add(new MailAddress(email.EmailCliente));

                        mail.Subject = "Locadora Rech: Devolução realizada com sucesso";

                        string corpoEmail = $"<h2><strong>Olá {email.NomeCliente}!</strong></h2>" +
                            $"<br/><h3>Houve uma locação de veículo recentemente fechada em seu nome." +
                            $"<br/>Segue em anexo o recibo contendo os dados da locação.</h3>" +
                            $"<br/><br/>Agradecemos a preferência, volte sempre!" +
                            $"<br/><i>Locadora Rech</i>";

                        mail.Body = corpoEmail;

                        mail.IsBodyHtml = true;

                        if (email.CaminhoArquivo != null)
                            mail.Attachments.Add(new Attachment(email.CaminhoArquivo));

                        smtp.Send(mail);

                    }
                    var collection = ArmazemDados.GetCollection<Email>();

                    collection.DeleteOne(x => x.EmailCliente.Equals(email.EmailCliente));

                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("emailCliente", email.EmailCliente);
                return false;
            }
        }
    }
}
