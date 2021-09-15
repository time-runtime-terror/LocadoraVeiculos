using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.ORM.LocacaoModule
{
    public class LocacaoRepositoryEF : ILocacaoRepository
    {
        public Locacao ConverterEmRegistro(IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Editar(int id, Locacao registro)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirNovo(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> ObtemParametrosRegistro(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public IList<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        public void RegistrarDevolucao(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            throw new NotImplementedException();
        }

        public IList<Locacao> SelecionarTodasLocacoesPendentes()
        {
            throw new NotImplementedException();
        }

        public IList<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
