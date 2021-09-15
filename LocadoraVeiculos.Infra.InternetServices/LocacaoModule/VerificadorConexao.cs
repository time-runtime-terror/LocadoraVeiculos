using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System.Net.NetworkInformation;

namespace LocadoraVeiculos.Infra.InternetServices.LocacaoModule
{
    public class VerificadorConexao : IVerificadorConexao
    {
        public bool TemConexaoComInternet()
        {
            string host = "www.google.com.br";

            bool result = false;
            Ping p = new Ping();

            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { }

            return result;
        }
    }
}
