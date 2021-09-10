using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.netCore.Controladores.FuncionarioModule
{
    public class ControladorFuncionario : Controlador<Funcionario>
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

        public override string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }


        public override Funcionario SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public override List<Funcionario> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
        }
        public override List<Funcionario> Pesquisar(string nome)
        {
            return Db.GetAll(sqlPesquisarFuncionarios, ConverterEmFuncionario, AdicionarParametro("NOME", nome + "%"));
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
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

        private Funcionario ConverterEmFuncionario(IDataReader reader)
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

        public bool ExisteFuncionario(string usuario, string senha)
        {
            return Db.Exists(sqlExisteFuncionarioLogin, AdicionarParametroFuncionario("NOMEUSUARIO", usuario, "SENHA", senha));
        }

        private Dictionary<string, object> AdicionarParametroFuncionario(string campoUsuario, object valorUsuario, string campoSenha, object valorSenha)
        {
            return new Dictionary<string, object>() { { campoUsuario, valorUsuario }, { campoSenha, valorSenha } };
        }
    }
}
