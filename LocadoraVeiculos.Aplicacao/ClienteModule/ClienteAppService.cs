using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.ClienteModule
{
    public class ClienteAppService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepo)
        {
            clienteRepository = clienteRepo;
        }

        public string InserirNovo(Cliente cliente)
        {
            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                clienteRepository.InserirNovo(cliente);

            return resultadoValidacao;
        }

        public string Editar(int id, Cliente cliente)
        {
            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                clienteRepository.Editar(id, cliente);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (clienteRepository.Excluir(id))
                return true;

            return false;
        }

        public Cliente SelecionarPorId(int id)
        {
            return clienteRepository.SelecionarPorId(id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return (List<Cliente>)clienteRepository.SelecionarTodos();
        }

        public List<Cliente> Pesquisar(string texto)
        {
            return (List<Cliente>)clienteRepository.Pesquisar(texto);
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            clienteRepository.AtualizarStatusLocacaoAtiva(cliente);
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            return (List<Cliente>)clienteRepository.SelecionarTodasPessoasFisicas();
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            return (List<Cliente>)clienteRepository.SelecionarTodasPessoasJuridicas();
        }
    }
}
