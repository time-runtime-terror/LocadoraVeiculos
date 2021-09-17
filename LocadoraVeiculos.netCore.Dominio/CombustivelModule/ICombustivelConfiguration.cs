namespace LocadoraVeiculos.netCore.Dominio.CombustivelModule
{
    public interface ICombustivelConfiguration
    {
        string GravarCombustivel(Combustivel registro);
        string PegarValorGasolina();
        string PegarValorEtanol();
        string PegarValorDiesel();
        string PegarValorGnv();
    }
}
