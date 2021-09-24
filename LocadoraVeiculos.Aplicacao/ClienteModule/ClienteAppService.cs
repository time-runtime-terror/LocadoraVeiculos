using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using log4net;
using log4net.Core;
using System;
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
            try
            {
                clienteRepository.AtualizarStatusLocacaoAtiva(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            List<Cliente> pessoasFisicas;
            try
            {
                pessoasFisicas = clienteRepository.SelecionarTodasPessoasFisicas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pessoasFisicas;
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            List<Cliente> pessoasJuridicas;
            try
            {
                pessoasJuridicas = clienteRepository.SelecionarTodasPessoasJuridicas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pessoasJuridicas;
        }
    }
}
