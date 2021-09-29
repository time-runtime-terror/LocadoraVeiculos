using LocadoraVeiculos.Infra.ExtensionMethods;
using LocadoraVeiculos.netCore.Dominio.Shared;
using Serilog;
using System;
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
        public virtual string InserirNovo(T registro)
        {
            Log.Logger.Aqui().Debug("Inserindo novo(a) {TipoRegistro}: {@Registro}",
                typeof(T).Name, registro);

            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    repositorio.InserirNovo(registro);

                    Log.Logger.Aqui().Debug("Inserção de {TipoRegistro} concluída com sucesso! ID: {IdRegistro}", typeof(T).Name, registro.Id);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Falha ao tentar inserir {TipoRegistro}! ID: {IdRegistro}", typeof(T).Name, registro.Id);
                }
            }

            return resultadoValidacao;
        }

        /// <summary>
        /// Edita um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro a ser editado</param>
        /// <param name="registro">Novo registro <typeparamref name="T"/> que irá substituir o antigo</param>
        /// <returns></returns>
        public virtual string Editar(int id, T registro)
        {
            Log.Logger.Aqui().Debug("Editando registro de {TipoRegistro}: {@Registro}", typeof(T).Name, registro);

            string resultadoValidacao = registro.Validar();

            try
            {
                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    repositorio.Editar(id, registro);

                    Log.Logger.Aqui().Debug("Edição de {TipoRegistro} concluída com sucesso! ID: {IdRegistro}", typeof(T).Name, registro.Id);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar editar {TipoRegistro}! ID: {Id}", typeof(T).Name, id);
            }

            return resultadoValidacao;
        }

        /// <summary>
        /// Exclui um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Valor <typeparamref name="bool"/> indicando se a exclusão foi bem-sucedida</returns>
        public virtual bool Excluir(int id)
        {
            Log.Logger.Aqui().Debug("Excluindo registro de {TipoRegistro} ID: {@IdRegistro}", typeof(T).Name, id);

            try
            { 
                if (repositorio.Excluir(id))
                {
                    Log.Logger.Aqui().Debug("Exclusão de {TipoRegistro} concluída com sucesso! ID: {IdRegistro}", typeof(T).Name, id);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar excluir {TipoRegistro}! ID: {IdRegistro}", typeof(T).Name, id);
            }
            
            return false;
        }

        /// <summary>
        /// Seleciona um registro do tipo <typeparamref name="T"/> previamente inserido.
        /// </summary>
        /// <param name="id">Identificador primário do registro à ser procurado</param>
        /// <returns>Registro <typeparamref name="T"/> ou <typeparamref name="null"/>, caso o registro não for encontrado.</returns>
        public T SelecionarPorId(int id)
        {
            Log.Logger.Aqui().Debug("Selecionando {TipoRegistro} por ID: {@IdRegistro}", typeof(T).Name, id);

            try
            {
                return repositorio.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar {TipoRegistro}! ID: {Id}", typeof(T).Name, id);
            }

            return null;
        }

        /// <summary>
        /// Seleciona uma lista de registros do tipo <typeparamref name="T"/> previamente inseridos.
        /// </summary>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        public List<T> SelecionarTodos()
        {
            Log.Logger.Aqui().Debug("Selecionando todos os registros de {TipoRegistro}", typeof(T).Name);

            try
            {
                return repositorio.SelecionarTodos();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar selecionar registros de {TipoRegistro}!", typeof(T).Name);
            }

            return null;
        }

        /// <summary>
        /// Pesquisa e filtra uma lista de registros do tipo <typeparamref name="T"/>.
        /// </summary>
        /// <param name="texto">String que servirá como filtro para a pesquisa</param>
        /// <returns>Lista de registros do tipo <typeparamref name="T"/> ou uma lista vazia, caso nenhum registro for encontrado.</returns>
        public List<T> Pesquisar(string texto)
        {
            Log.Logger.Aqui().Debug("Pesquisando registros de {TipoRegistro}", typeof(T).Name);

            try
            {
                return repositorio.Pesquisar(texto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar pesquisar registros de {TipoRegistro}", typeof(T).Name);
            }

            return null;
        }
    }
}
