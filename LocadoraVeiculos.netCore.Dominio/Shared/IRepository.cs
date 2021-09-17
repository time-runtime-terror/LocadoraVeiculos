using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.netCore.Dominio.Shared
{
    public interface IRepository<T> where T : EntidadeBase
    {
        /// <summary>
        /// Insere um novo registro do tipo <typeparamref name="T"/> no repositório
        /// </summary>
        /// <param name="registro"><typeparamref name="T"/> que será inserido</param>
        void InserirNovo(T registro);

        /// <summary>
        /// Edita um registro do tipo <typeparamref name="T"/> já inserido
        /// </summary>
        /// <param name="id">Identificador primário do registro <typeparamref name="T"/> que será editado</param>
        /// <param name="registro">Novo registro do tipo <typeparamref name="T"/> que irá substituir o antigo</param>
        void Editar(int id, T registro);

        /// <summary>
        /// Exclui um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro <typeparamref name="T"/> que será excluído</param>
        /// <returns>Valor <typeparamref name="bool"/> indicando se a exclusão foi bem-sucedida</returns>
        bool Excluir(int id);

        /// <summary>
        /// Procura saber se um registro do tipo <typeparamref name="T"/> existe na base de dados
        /// </summary>
        /// <param name="id">Identificador primário do registro <typeparamref name="T"/> que será pesquisado</param>
        /// <returns>Valor <typeparamref name="bool"/> indicando se o registro existe ou não</returns>
        bool Existe(int id);

        /// <summary>
        /// Seleciona um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro à ser procurado</param>
        /// <returns>Registro <typeparamref name="T"/> ou <typeparamref name="null"/>, caso o registro não for encontrado.</returns>
        T SelecionarPorId(int id);

        /// <summary>
        /// Seleciona uma lista de registros do tipo <typeparamref name="T"/> previamente inseridos.
        /// </summary>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        List<T> SelecionarTodos();

        /// <summary>
        /// Pesquisa e filtra uma lista de registros do tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="texto">String que servirá como filtro para a pesquisa</param>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        List<T> Pesquisar(string texto);

        /// <summary>
        /// Extrai as propriedades de um registro do tipo <typeparamref name="T"/> e as retorna como um dicionário
        /// </summary>
        /// <param name="registro">Registro à ser extraído</param>
        /// <returns>Dicionário contendo as propriedades ou atributos do registro separados por chave e valor</returns>
        Dictionary<string, object> ObtemParametrosRegistro(T registro);

        /// <summary>
        /// Converte os dados vindos de um objeto <typeparamref name="IDataReader"/> para um registro <typeparamref name="T"/>
        /// </summary>
        /// <param name="reader">Objeto <typeparamref name="IDataReader"/> que será convertido em <typeparamref name="T"/></param>
        /// <returns>Registro do tipo <typeparamref name="T"/> convertido</returns>
        T ConverterEmRegistro(IDataReader reader);
    }
}
