using LocadoraVeiculos.Aplicacao.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using Serilog;
using System;
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

        public void AtualizarStatusLocacaoAtiva(Cliente cliente, bool temLocacao)
        {
            cliente.TemLocacaoAtiva = temLocacao;

            try
            {
                clienteRepository.AtualizarStatusLocacaoAtiva(cliente);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha a atualizar status de locação do Cliente Id: {Id}", cliente.Id);
            }
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            try
            {
                return clienteRepository.SelecionarTodasPessoasFisicas();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return null;
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            try
            {
                return clienteRepository.SelecionarTodasPessoasJuridicas();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }

            return null;
        }
    }
}
