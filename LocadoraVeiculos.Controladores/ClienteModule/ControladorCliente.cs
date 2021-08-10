using LocadoraVeiculos.Controladores.CondutorModule;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.ClienteModule
{
    public class ControladorCliente : Controlador<Cliente>
    {
        private readonly ControladorCondutor controladorCondutor;

        public ControladorCliente(ControladorCondutor controladorCondutor)
        {
            this.controladorCondutor = controladorCondutor;
        }

        #region Queries
        private const string sqlInserirCliente =
            @"INSERT INTO TBCLIENTE 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE], 
		                [TIPOPESSOA],
                        [CPF], 
		                [CNPJ],
		                [RG],
		                [DATAVENCIMENTOCNH],
		                [ID_CONDUTOR]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @ENDERECO,
                        @TELEFONE,
		                @TIPOPESSOA, 
		                @CPF,
		                @CNPJ,
		                @RG,
		                @DATAVENCIMENTOCNH,
		                @ID_CONDUTOR,
	                )";

        private const string sqlEditarCliente =
            @"UPDATE TBCLIENTE
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [TIPOPESSOA] = @TIPOPESSOA,
                        [CPF] = @CPF,
                        [CNPJ] = @CNPJ,
                        [RG] = @RG,
                        [DATAVENCIMENTOCNH] = @DATAVENCIMENTOCNH,
                        [ID_CONDUTOR] = @ID_CONDUTOR,
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
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOPESSOA],
                        CL.[CPF], 
		                CL.[CNPJ],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_CONDUTOR]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCONDUTOR] AS CD
                    ON
                        CD.ID = CL.ID_CONDUTOR
                    WHERE 
                        CL.[ID] = @ID";

        private const string sqlSelecionarTodosClientes =
            @"SELECT
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOPESSOA],
                        CL.[CPF], 
		                CL.[CNPJ],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_CONDUTOR]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCONDUTOR] AS CD
                    ON
                        CD.ID = CL.ID_CONDUTOR";

        private const string sqlExisteCliente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";
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

        private Dictionary<string, object> ObtemParametrosCliente(Cliente cliente)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", cliente.Id);
            parametros.Add("NOME", cliente.Nome);
            parametros.Add("ENDERECO", cliente.Endereco);
            parametros.Add("TELEFONE", cliente.Telefone);
            parametros.Add("TIPOPESSOA", cliente.TipoPessoa);
            parametros.Add("CPF", cliente.CPF);
            parametros.Add("CNPJ", cliente.CNPJ);
            parametros.Add("RG", cliente.RG);
            parametros.Add("DATAVENCIMENTOCNH", cliente.VencimentoCnh);

            var idCondutor = cliente.Condutor?.Id;

            parametros.Add("ID_CONDUTOR", idCondutor);

            return parametros;
        }

        private Cliente ConverterEmCliente(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string tipoPessoa = Convert.ToString(reader["TIPOPESSOA"]);
            string cnh = Convert.ToString(reader["CNH"]);
            DateTime vencimentoCnh = Convert.ToDateTime(reader["DATAVENCIMENTOCNH"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            var condutor = controladorCondutor.SelecionarPorId(Convert.ToInt32(reader["ID_CONDUTOR"]));

            Cliente cliente = new Cliente(nome, endereco, telefone, tipoPessoa, cnh, vencimentoCnh, cpf, cnpj, condutor);

            cliente.Id = id;

            return cliente;
        }
    }
}
