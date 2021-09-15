using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface INotificadorEmail
    {
        Task EnviarEmailAsync(Locacao locacao, string nomeArquivo);
    }
}
