using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.LocacaoModule
{
    public interface ISolicitacaoEmailRepository : IRepository<SolicitacaoEmail>
    {
        List<SolicitacaoEmail> SelecionarTodasSolicitacoesPendentes();
    }
}
