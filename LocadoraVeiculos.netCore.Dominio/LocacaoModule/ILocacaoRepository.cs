using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        string RegistrarDevolucao(Locacao registro);
        IList<Locacao> SelecionarTodasLocacoesConcluidas();
        IList<Locacao> SelecionarTodasLocacoesPendentes();
    }
}
