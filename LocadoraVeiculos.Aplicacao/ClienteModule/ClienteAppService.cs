using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using log4net;
using log4net.Core;
using System.Collections.Generic;
using System.Reflection;

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
