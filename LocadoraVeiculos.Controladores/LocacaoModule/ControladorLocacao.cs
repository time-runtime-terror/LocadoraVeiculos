using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.LocacaoModule
{
    public class ControladorLocacao : Controlador<Locacao>
    {
        #region Queries
        private const string sqlInserirLocacao =
            @"INSERT INTO TBLOCACAO 
	                (
		                [ID_CLIENTE], 
		                [ID_VEICULO], 
		                [PLANO], 
		                [DATASAIDA],
                        [DATADEVOLUCAO], 
                        [CAUCAO],
                        [DEVOLUCAO]
	                ) 
	                VALUES
	                (
                        @ID_CLIENTE, 
                        @ID_VEICULO,
                        @PLANO,
		                @DATASAIDA, 
		                @DATADEVOLUCAO,
                        @CAUCAO,
                        @DEVOLUCAO
	                )";

        private const string sqlEditarLocacao =
            @"UPDATE TBLOCACAO
                    SET
                        [ID_CLIENTE] = @ID_CLIENTE,
		                [ID_VEICULO] = @ID_VEICULO, 
		                [PLANO] = @PLANO,
                        [DATASAIDA] = @DATASAIDA,
                        [DATADEVOLUCAO] = @DATADEVOLUCAO,
                        [CAUCAO] = @CAUCAO
                    WHERE 
                        ID = @ID";

        private const string sqlRegistrarDevolucao =
            @"UPDATE TBLOCACAO
                    SET
                        [DEVOLUCAO] = @DEVOLUCAO
                    WHERE
                        [ID] = @ID";

        private const string sqlExcluirLocacao =
            @"DELETE 
	                FROM
                        TBLOCACAO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT
                        LO.[ID],
		                LO.[ID_CLIENTE], 
		                LO.[ID_VEICULO], 
		                LO.[DATASAIDA], 
		                LO.[DATADEVOLUCAO], 
		                LO.[PLANO],
		                LO.[CAUCAO],
                        LO.[DEVOLUCAO]
	                FROM
                        [TBLOCACAO] AS LO JOIN
                        [TBCLIENTE] AS CL
                    ON
                        CL.ID = LO.ID_CLIENTE JOIN
                        [TBVEICULO] AS VE
                    ON
                        VE.ID = LO.ID_VEICULO
                    WHERE 
                        LO.[ID] = @ID";

        private const string sqlSelecionarTodasLocacoes =
            @"SELECT
                        LO.[ID],
		                LO.[ID_CLIENTE], 
		                LO.[ID_VEICULO], 
		                LO.[DATASAIDA], 
		                LO.[DATADEVOLUCAO], 
		                LO.[PLANO],
		                LO.[CAUCAO],
                        LO.[DEVOLUCAO]
	                FROM
                        [TBLOCACAO] AS LO JOIN
                        [TBCLIENTE] AS CL
                        ON
                        CL.ID = LO.ID_CLIENTE JOIN
                        [TBVEICULO] AS VE
                    ON
                        VE.ID = LO.ID_VEICULO";

        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";

        private const string sqlPesquisarLocacoes = "";

        #endregion

        private readonly ControladorCliente controladorCliente;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorTaxasServicos controladorTaxasServicos;

        public ControladorLocacao(ControladorCliente ctrlC, ControladorVeiculo ctrlV, ControladorTaxasServicos ctrlT)
        {
            controladorCliente = ctrlC;
            controladorVeiculo = ctrlV;
            controladorTaxasServicos = ctrlT;
        }

        public override string InserirNovo(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }

        public string RegistrarDevolucao(Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            Dictionary<string, object> parametros = new Dictionary<string, object>();

            var devolucao = (string.IsNullOrEmpty(registro.Devolucao)) ? null : registro.Devolucao;

            parametros.Add("DEVOLUCAO", devolucao);
            parametros.Add("ID", registro.Id);

            if (resultadoValidacao == "ESTA_VALIDO")
                Db.Update(sqlRegistrarDevolucao, parametros);

            return resultadoValidacao;
        }

        public override string Editar(int id, Locacao registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
        }

        public override Locacao SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AdicionarParametro("ID", id));
        }

        public override List<Locacao> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmLocacao);
        }

        public override List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("ID_VEICULO", locacao.Veiculo.Id);
            parametros.Add("ID_CLIENTE", locacao.Cliente.Id);
            parametros.Add("PLANO", locacao.Plano);
            parametros.Add("DATASAIDA", locacao.DataSaida);
            parametros.Add("DATADEVOLUCAO", locacao.DataDevolucao);
            parametros.Add("CAUCAO", locacao.Caucao);
            parametros.Add("DEVOLUCAO", "Pendente");

            return parametros;
        }

        private Locacao ConverterEmLocacao(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);
            int idCliente = Convert.ToInt32(reader["ID_CLIENTE"]);
            string plano = Convert.ToString(reader["PLANO"]);
            DateTime dataSaida = Convert.ToDateTime(reader["DATASAIDA"]);
            DateTime dataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
            double caucao = Convert.ToDouble(reader["CAUCAO"]);
            string devolucao = Convert.ToString(reader["DEVOLUCAO"]);

            Veiculo veiculo = controladorVeiculo.SelecionarPorId(idVeiculo);
            Cliente cliente = controladorCliente.SelecionarPorId(idCliente);

            List<TaxasServicos> taxas = controladorTaxasServicos.SelecionarTaxasServicosUsados(id);

            List<TaxasServicos> taxasSelecionadas = (taxas.Count == 0) ? null : taxas;

            Locacao locacao = new Locacao(cliente, veiculo, taxasSelecionadas, dataSaida, dataDevolucao,
                caucao, plano, devolucao);

            locacao.Id = id;

            return locacao;
        }
    }
}
