using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.ClienteModule
{
    public class ControladorCliente : Controlador<Cliente>
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

        public override string InserirNovo(Cliente registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCliente, ObtemParametrosCliente(registro));
            }

            return resultadoValidacao;
        }
        public override string Editar(int id, Cliente registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCliente, ObtemParametrosCliente(registro));
            }

            return resultadoValidacao;
        }

        public void AtualizarStatusLocacaoAtiva(Cliente cliente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cliente.Id);
            parametros.Add("TEM_LOCACAO", cliente.TemLocacaoAtiva);

            Db.Update(sqlAtualizarStatusLocacao, parametros);
        }

        public override bool Excluir(int id)
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

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
        }

        public override Cliente SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarClientePorId, ConverterEmCliente, AdicionarParametro("ID", id));
        }

        public override List<Cliente> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmCliente);
        }

        public List<Cliente> SelecionarTodasPessoasFisicas()
        {
            return Db.GetAll(sqlSelecionarTodasPessoasFisicas, ConverterEmCliente);
        }

        public List<Cliente> SelecionarTodasPessoasJuridicas()
        {
            return Db.GetAll(sqlSelecionarTodasPessoasJuridicas, ConverterEmCliente);
        }

        public override List<Cliente> Pesquisar(string nome)
        {
            return Db.GetAll(sqlPesquisarClientes, ConverterEmCliente, AdicionarParametro("NOME", nome + "%"));
        }

        private Dictionary<string, object> ObtemParametrosCliente(Cliente cliente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cliente.Id);
            parametros.Add("NOME", cliente.Nome);
            parametros.Add("EMAIL", cliente.Email);
            parametros.Add("ENDERECO", cliente.Endereco);
            parametros.Add("TELEFONE", cliente.Telefone);
            parametros.Add("TIPOCADASTRO", cliente.TipoCadastro);
            parametros.Add("NUMEROCADASTRO", cliente.NumeroCadastro);
            parametros.Add("CNH", cliente.CNH);
            parametros.Add("RG", cliente.RG);
            parametros.Add("DATAVENCIMENTOCNH", cliente.VencimentoCnh);

            var idEmpresa = cliente.Empresa?.Id;

            parametros.Add("ID_EMPRESA", idEmpresa);

            return parametros;
        }

        private Cliente ConverterEmCliente(IDataReader reader)
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
