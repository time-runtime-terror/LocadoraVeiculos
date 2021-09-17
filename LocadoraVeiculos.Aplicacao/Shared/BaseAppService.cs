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

        /// <summary>
        /// Insere um novo registro do tipo <typeparamref name="T"/>
        /// </summary>
        /// <param name="registro"></param>
        /// <returns>Resultado da validação do registro inserido</returns>
        public string InserirNovo(T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                repositorio.InserirNovo(registro);

            return resultadoValidacao;
        }

        /// <summary>
        /// Edita um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro a ser editado</param>
        /// <param name="registro">Novo registro <typeparamref name="T"/> que irá substituir o antigo</param>
        /// <returns></returns>
        public string Editar(int id, T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                repositorio.Editar(id, registro);

            return resultadoValidacao;
        }

        /// <summary>
        /// Exclui um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor <typeparamref name="bool"/> indicando se a exclusão foi bem-sucedida</returns>
        public bool Excluir(int id)
        {
            if (repositorio.Excluir(id))
                return true;

            return false;
        }

        /// <summary>
        /// Seleciona um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro à ser procurado</param>
        /// <returns>Registro <typeparamref name="T"/> ou <typeparamref name="null"/>, caso o registro não for encontrado.</returns>
        public T SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona uma lista de registros do tipo <typeparamref name="T"/> previamente inseridos.
        /// </summary>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        public List<T> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }

        /// <summary>
        /// Pesquisa e filtra uma lista de registros do tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="texto">String que servirá como filtro para a pesquisa</param>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        public List<T> Pesquisar(string texto)
        {
            return repositorio.Pesquisar(texto);
        }
    }
}
