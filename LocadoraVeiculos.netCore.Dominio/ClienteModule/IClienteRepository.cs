using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.netCore.Dominio.ClienteModule
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void AtualizarStatusLocacaoAtiva(Cliente cliente);
        List<Cliente> SelecionarTodasPessoasFisicas();
        List<Cliente> SelecionarTodasPessoasJuridicas();
    }
}
