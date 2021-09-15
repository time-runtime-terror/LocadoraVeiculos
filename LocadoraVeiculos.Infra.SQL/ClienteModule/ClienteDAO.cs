using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.SQL.ClienteModule
{
    public class ClienteDAO : BaseDAO, IClienteRepository
    {
        #region Queries
        private const string sqlInserirCliente =
            @"INSERT INTO TBCLIENTE 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE], 
		                [TIPOCADASTRO],
                        [NUMEROCADASTRO], 
                        [CNH],
		                [RG],
		                [DATAVENCIMENTOCNH],
		                [ID_EMPRESA],
                        [EMAIL]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @ENDERECO,
                        @TELEFONE,
		                @TIPOCADASTRO, 
		                @NUMEROCADASTRO,
                        @CNH,
		                @RG,
		                @DATAVENCIMENTOCNH,
		                @ID_EMPRESA,
                        @EMAIL
	                )";

        private const string sqlEditarCliente =
            @"UPDATE TBCLIENTE
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [TIPOCADASTRO] = @TIPOCADASTRO,
                        [NUMEROCADASTRO] = @NUMEROCADASTRO,
                        [CNH] = @CNH,
                        [RG] = @RG,
                        [DATAVENCIMENTOCNH] = @DATAVENCIMENTOCNH,
                        [ID_EMPRESA] = @ID_EMPRESA,
                        [EMAIL] = @EMAIL
                    WHERE 
                        ID = @ID";

        private const string sqlAtualizarStatusLocacao =
            @"UPDATE TBCLIENTE
                    SET
                        [TEM_LOCACAO] = @TEM_LOCACAO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCliente =
            @"DELETE 
	                FROM
                        TBCLIENTE
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarClientePorId =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA],
                        CL.[EMAIL],
                        CL.[TEM_LOCACAO]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE 
                        CL.[ID] = @ID";

        private const string sqlSelecionarTodosClientes =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA],
                        CL.[EMAIL],
                        CL.[TEM_LOCACAO]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA";

        private const string sqlSelecionarTodasPessoasFisicas =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA],
                        CL.[EMAIL],
                        CL.[TEM_LOCACAO]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE
                        CL.[TIPOCADASTRO] = 'CPF'";

        private const string sqlSelecionarTodasPessoasJuridicas =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA],
                        CL.[EMAIL],
                        CL.[TEM_LOCACAO]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE
                        CL.[TIPOCADASTRO] = 'CNPJ'";

        private const string sqlExisteCliente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";

        private const string sqlPesquisarClientes =
                        @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA],
                        CL.[EMAIL],
                        CL.[TEM_LOCACAO]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE
                        CL.[NOME] LIKE @NOME";
        #endregion

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cliente.Id);
            parametros.Add("TEM_LOCACAO", cliente.TemLocacaoAtiva);

            Db.Update(sqlAtualizarStatusLocacao, parametros);
        }

        public IList<Cliente> SelecionarTodasPessoasFisicas()
        {
            return Db.GetAll(sqlSelecionarTodasPessoasFisicas, ConverterEmRegistro);
        }

        public IList<Cliente> SelecionarTodasPessoasJuridicas()
        {
            return Db.GetAll(sqlSelecionarTodasPessoasJuridicas, ConverterEmRegistro);
        }

        public void InserirNovo(Cliente registro)
        {
            registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosRegistro(registro));
        }

        public void Editar(int id, Cliente registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarCliente, ObtemParametrosRegistro(registro));
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCliente, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }


        public IList<Cliente> Pesquisar(string texto)
        {
            return Db.GetAll(sqlPesquisarClientes, ConverterEmRegistro, AdicionarParametro("NOME", texto + "%"));
        }

        public Cliente SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarClientePorId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }

        public IList<Cliente> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmRegistro);
        }

        public Dictionary<string, object> ObtemParametrosRegistro(Cliente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("TIPOCADASTRO", registro.TipoCadastro);
            parametros.Add("NUMEROCADASTRO", registro.NumeroCadastro);
            parametros.Add("CNH", registro.CNH);
            parametros.Add("RG", registro.RG);
            parametros.Add("DATAVENCIMENTOCNH", registro.VencimentoCnh);

            var idEmpresa = registro.Empresa?.Id;

            parametros.Add("ID_EMPRESA", idEmpresa);

            return parametros;
        }

        public Cliente ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string email = Convert.ToString(reader["EMAIL"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string tipoCadastro = Convert.ToString(reader["TIPOCADASTRO"]);
            string cnh = Convert.ToString(reader["CNH"]);
            string documento = Convert.ToString(reader["NUMEROCADASTRO"]);
            string rg = Convert.ToString(reader["RG"]);
            DateTime? vencimentoCnh = null;
            bool temLocacaoAtiva = Convert.ToBoolean(reader["TEM_LOCACAO"]);

            if (reader["DATAVENCIMENTOCNH"] != DBNull.Value)
                vencimentoCnh = Convert.ToDateTime(reader["DATAVENCIMENTOCNH"]);

            Cliente empresa = null;

            if (reader["ID_EMPRESA"] != DBNull.Value)
                empresa = this.SelecionarPorId(Convert.ToInt32(reader["ID_EMPRESA"]));

            Cliente cliente = new Cliente(nome, email, endereco, telefone, tipoCadastro, cnh, vencimentoCnh, documento, rg, empresa);

            cliente.Id = id;
            cliente.TemLocacaoAtiva = temLocacaoAtiva;

            return cliente;
        }
    }
}
