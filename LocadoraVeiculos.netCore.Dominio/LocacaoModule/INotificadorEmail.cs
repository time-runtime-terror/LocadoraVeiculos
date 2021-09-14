namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface INotificadorEmail
    {
        void EnviarEmailAsync(string caminhoRecibo);
    }
}
