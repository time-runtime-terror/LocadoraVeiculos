using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.ClienteModule
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void AtualizarStatusLocacaoAtiva(Cliente cliente);
        IList<Cliente> SelecionarTodasPessoasFisicas();
        IList<Cliente> SelecionarTodasPessoasJuridicas();
    }
}
