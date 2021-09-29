using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface INotificadorEmail
    {
        Task EnviarEmailAsync(Email email, string nomeArquivo);
        Task AgendarEnvioEmailAsync(Email email, string nomeArquivo);
        Task EnviarEmailsAgendadosAsync();
    }
}
