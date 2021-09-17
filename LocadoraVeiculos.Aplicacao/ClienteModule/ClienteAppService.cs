using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ClienteModule
{
    public class ClienteAppService : BaseAppService<Cliente>
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepo) : base(clienteRepo)
        {
            clienteRepository = clienteRepo;
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            clienteRepository.AtualizarStatusLocacaoAtiva(cliente);
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            return clienteRepository.SelecionarTodasPessoasFisicas();
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            return clienteRepository.SelecionarTodasPessoasJuridicas();
        }
    }
}
