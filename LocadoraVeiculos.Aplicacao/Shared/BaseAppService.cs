using LocadoraVeiculos.netCore.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.Shared
{
    public abstract class BaseAppService<T> where T : EntidadeBase
    {
        protected readonly IRepository<T> repositorio;

        protected BaseAppService(IRepository<T> repo)
        {
            repositorio = repo;
        }

        public string InserirNovo(T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                repositorio.InserirNovo(registro);

            return resultadoValidacao;
        }

        public string Editar(int id, T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                repositorio.Editar(id, registro);

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (repositorio.Excluir(id))
                return true;

            return false;
        }

        public T SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<T> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }

        public List<T> Pesquisar(string texto)
        {
            return repositorio.Pesquisar(texto);
        }
    }
}
