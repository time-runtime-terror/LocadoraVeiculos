namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface INotificadorEmail
    {
        bool EnviarEmail(SolicitacaoEmail email);
    }
}
