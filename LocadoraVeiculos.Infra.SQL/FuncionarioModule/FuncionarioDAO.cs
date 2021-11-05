using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDAO : BaseDAO<Funcionario>, IFuncionarioRepository
    {

        #region Queries
        private const string sqlInserirFuncionario =
            @"INSERT INTO TBFUNCIONARIO 
	                (
		                [NOME], 
		                [NOMEUSUARIO], 
		                [SENHA],
                        [DATAENTRADA], 
		                [SALARIO]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @NOMEUSUARIO,
                        @SENHA,
		                @DATAENTRADA, 
		                @SALARIO
	                )";

        private const string sqlEditarFuncionario =
            @"UPDATE TBFUNCIONARIO
                    SET
                        [NOME] = @NOME,
		                [NOMEUSUARIO] = @NOMEUSUARIO, 
		                [SENHA] = @SENHA,
                        [DATAENTRADA] = @DATAENTRADA,
                        [SALARIO] = @SALARIO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirFuncionario =
            @"DELETE 
	                FROM
                        TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarFuncionarioPorId =
            @"SELECT
                        [ID],
		                [NOME], 
		                [NOMEUSUARIO], 
		                [SENHA],
                        [DATAENTRADA], 
		                [SALARIO]
	                FROM
                        TBFUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosFuncionarios =
            @"SELECT
                        [ID],
		                [NOME], 
		                [NOMEUSUARIO], 
		                [SENHA],
                        [DATAENTRADA], 
		                [SALARIO]
	                FROM
                        TBFUNCIONARIO";

        private const string sqlExisteFuncionario =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBFUNCIONARIO]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteFuncionarioLogin =
             @"SELECT 
                COUNT(*) 
            FROM 
                [TBFUNCIONARIO]
            WHERE 
                [NOMEUSUARIO] = @NOMEUSUARIO
             AND
                [SENHA] = @SENHA";

        private const string sqlPesquisarFuncionarios =
            @"SELECT
                        [ID],
		                [NOME], 
		                [NOMEUSUARIO], 
		                [SENHA],
                        [DATAENTRADA], 
		                [SALARIO]
	                FROM
                        TBFUNCIONARIO
                    WHERE 
                        [NOME] LIKE @NOME";
        #endregion


        public void InserirNovo(Funcionario funcionario)
        {
            try
            {
                funcionario.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosRegistro(funcionario));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlInserirFuncionario", sqlInserirFuncionario);
                throw ex;
            }

        }

        public void Editar(int id, Funcionario funcionario)
        {
            funcionario.Id = id;
            try
            {
                Db.Update(sqlEditarFuncionario, ObtemParametrosRegistro(funcionario));
            }catch (Exception ex)
            {
                ex.Data.Add("sqlEditarFuncionario", sqlEditarFuncionario);
                throw ex;
            }

        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlExcluirFuncionario", sqlExcluirFuncionario);
                throw ex;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
            }
            catch(Exception ex)
            {
                ex.Data.Add("sqlExisteFuncionario", sqlExisteFuncionario);
                throw ex;
            }
            
        }


        public List<Funcionario> SelecionarTodos()
        {
            try
            {
                return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmRegistro);
            }
            catch(Exception ex)
            {
                ex.Data.Add("sqlSelecionarTodosFuncionarios", sqlSelecionarTodosFuncionarios);
                throw ex;
            }
            
        }

        public Funcionario SelecionarPorId(int id)
        {
            try
            {
                return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
            }
            catch(Exception ex)
            {
                ex.Data.Add("sqlSelecionarFuncionarioPorId", sqlSelecionarFuncionarioPorId);
                throw ex;
            }
        }

        public List<Funcionario> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        public override Funcionario ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string nomeUsuario = Convert.ToString(reader["NOMEUSUARIO"]);
            string senha = Convert.ToString(reader["SENHA"]);
            DateTime dataEntrada = Convert.ToDateTime(reader["DATAENTRADA"]);
            string salario = Convert.ToString(reader["SALARIO"]);

            Funcionario funcionario = new Funcionario(nome, nomeUsuario, senha, dataEntrada, salario);

            funcionario.Id = id;

            return funcionario;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("NOMEUSUARIO", funcionario.NomeUsuario);
            parametros.Add("SENHA", funcionario.Senha);
            parametros.Add("DATAENTRADA", funcionario.DataEntrada);
            parametros.Add("SALARIO", funcionario.Salario);

            return parametros;
        }

        public bool ExisteFuncionario(string usuario, string senha)
        {
            try
            {
                return Db.Exists(sqlExisteFuncionarioLogin, AdicionarParametroFuncionario("NOMEUSUARIO", usuario, "SENHA", senha));
            }
            catch(Exception ex)
            {
                ex.Data.Add("sqlExisteFuncionarioLogin", sqlExisteFuncionarioLogin);
                throw ex;
            }
            
        }

        public Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            return new Dictionary<string, object>() { { campoUsuario, valorUsuario }, { campoSenha, valorSenha } };
        }
    }
}
