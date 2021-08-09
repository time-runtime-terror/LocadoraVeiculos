using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.Shared
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        #region Queries SQL Abstratas

        protected abstract string SqlInsercao { get; }
        protected abstract string SqlEdicao { get; }
        protected abstract string SqlExclusao { get; }
        protected abstract string SqlSelecionarPorId { get; }
        protected abstract string SqlSelecionarTodos { get; }
        protected abstract string SqlExisteRegistro { get; }

        #endregion

        public virtual string InserirNovo(T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "REGISTRO_VALIDO")
                registro.Id = Db.Insert(SqlInsercao, ObtemParametrosRegistro(registro));

            return resultadoValidacao;
        }

        public virtual string Editar(int id, T registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "REGISTRO_VALIDO")
            {
                registro.Id = id;
                Db.Update(SqlEdicao, ObtemParametrosRegistro(registro));
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            if (!ConseguiuExcluir(id))
                return false;

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(SqlExisteRegistro, AdicionarParametro("ID", id));
        }

        public List<T> SelecionarTodos()
        {
            return Db.GetAll(SqlSelecionarTodos, ConverterEmRegistro);
        }

        public T SelecionarPorId(int id)
        {
            return Db.Get(SqlSelecionarPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        private bool ConseguiuExcluir(int id)
        {
            try
            {
                Db.Delete(SqlExclusao, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #region Métodos Abstratos

        protected abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);

        protected abstract T ConverterEmRegistro(IDataReader reader);

        #endregion

    }
}
