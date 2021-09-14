namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface IGeradorRecibo
    {
        string GerarRecibo(Locacao locacao);
    }
}
