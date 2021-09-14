using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        void RegistrarDevolucao(Locacao registro);
        IList<Locacao> SelecionarTodasLocacoesConcluidas();
        IList<Locacao> SelecionarTodasLocacoesPendentes();
    }
}
