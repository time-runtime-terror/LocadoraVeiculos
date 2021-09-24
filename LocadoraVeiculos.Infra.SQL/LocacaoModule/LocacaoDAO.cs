using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Infra.SQL.LocacaoModule
{
    public class LocacaoDAO : BaseDAO, ILocacaoRepository
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
                        [CONDUTOR],
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
                        @CONDUTOR,
                        @DEVOLUCAO
	                )";

        private const string sqlInserirTaxaSelecionada =
            @"INSERT INTO [TBTAXASSERVICOS_USADOS]
                    (
                       [ID_LOCACAO],
                       [ID_TAXASSERVICOS]
                    )
                 VALUES
                    (
                      @ID_LOCACAO,
                      @ID_TAXASSERVICOS
	                )";

        private const string sqlEditarLocacao =
            @"UPDATE TBLOCACAO
                    SET
                        [ID_CLIENTE] = @ID_CLIENTE,
		                [ID_VEICULO] = @ID_VEICULO, 
		                [PLANO] = @PLANO,
                        [DATASAIDA] = @DATASAIDA,
                        [DATADEVOLUCAO] = @DATADEVOLUCAO,
                        [CAUCAO] = @CAUCAO,
                        [CONDUTOR] = @CONDUTOR
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

        private const string sqlExcluirTaxasServicosUsados =
            @"DELETE 
	                FROM
                        TBTAXASSERVICOS_USADOS
                    WHERE 
                        ID_LOCACAO = @ID";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT
                        LO.[ID],
		                LO.[ID_CLIENTE], 
		                LO.[ID_VEICULO], 
		                LO.[DATASAIDA], 
		                LO.[DATADEVOLUCAO], 
		                LO.[PLANO],
		                LO.[CAUCAO],
                        LO.[CONDUTOR],
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
                        LO.[CONDUTOR],
                        LO.[DEVOLUCAO]
	                FROM
                        [TBLOCACAO] AS LO JOIN
                        [TBCLIENTE] AS CL
                        ON
                        CL.ID = LO.ID_CLIENTE JOIN
                        [TBVEICULO] AS VE
                    ON
                        VE.ID = LO.ID_VEICULO";

        private const string sqlSelecionarTodasLocacoesConcluidas =
            @"SELECT
                        LO.[ID],
		                LO.[ID_CLIENTE], 
		                LO.[ID_VEICULO], 
		                LO.[DATASAIDA], 
		                LO.[DATADEVOLUCAO], 
		                LO.[PLANO],
		                LO.[CAUCAO],
                        LO.[CONDUTOR],
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
                        LO.[DEVOLUCAO] != 'Pendente'";

        private const string sqlSelecionarTodasLocacoesPendentes =
            @"SELECT
                        LO.[ID],
		                LO.[ID_CLIENTE], 
		                LO.[ID_VEICULO], 
		                LO.[DATASAIDA], 
		                LO.[DATADEVOLUCAO], 
		                LO.[PLANO],
		                LO.[CAUCAO],
                        LO.[CONDUTOR],
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
                        LO.[DEVOLUCAO] = 'Pendente'";

        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";

        private const string sqlPesquisarLocacoes = "";

        #endregion

        private readonly ClienteDAO _clienteRepository;
        private readonly VeiculosDAO _veiculoRepository;
        private readonly TaxasServicosDAO _taxaRepository;

        public LocacaoDAO(ClienteDAO clienteRepo, VeiculosDAO veiculoRepo, TaxasServicosDAO taxaRepo)
        {
            _clienteRepository = clienteRepo;
            _veiculoRepository = veiculoRepo;
            _taxaRepository = taxaRepo;
        }

        public void InserirNovo(Locacao locacao)
        {
            try
            {
                locacao.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosRegistro(locacao));

                foreach (TaxasServicos taxa in locacao.Taxas)
                {
                    var parametros = new Dictionary<string, object>();

                    parametros.Add("ID_LOCACAO", locacao.Id);
                    parametros.Add("ID_TAXASSERVICOS", taxa.Id);

                    Db.Insert(sqlInserirTaxaSelecionada, parametros);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery1", sqlInserirLocacao);
                ex.Data.Add("sqlQuery2", sqlInserirTaxaSelecionada);
                throw ex;
            }
        }

        public void RegistrarDevolucao(Locacao registro)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            var devolucao = (string.IsNullOrEmpty(registro.Devolucao)) ? null : registro.Devolucao;

            parametros.Add("DEVOLUCAO", devolucao);
            parametros.Add("ID", registro.Id);

            try
            {
                Db.Update(sqlRegistrarDevolucao, parametros);

                Db.Delete(sqlExcluirTaxasServicosUsados, AdicionarParametro("ID", registro.Id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery1", sqlRegistrarDevolucao);
                ex.Data.Add("sqlQuery2", sqlExcluirTaxasServicosUsados);
                throw ex;
            }

        }

        public void Editar(int id, Locacao registro)
        {
            registro.Id = id;

            try
            {
                Db.Update(sqlEditarLocacao, ObtemParametrosRegistro(registro));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlEditarLocacao);
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlExcluirLocacao);
                throw ex;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                return Db.Exists(sqlExisteLocacao, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlExisteLocacao);
                throw ex;
            }
        }

        public Locacao SelecionarPorId(int id)
        {
            try
            {
                return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlSelecionarLocacaoPorId);
                throw ex;
            }
        }

        public List<Locacao> SelecionarTodos()
        {
            try
            {
                return Db.GetAll(sqlSelecionarTodasLocacoes, ConverterEmRegistro);
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlSelecionarTodasLocacoes);
                throw ex;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesConcluidas()
        {
            try
            {
                return Db.GetAll(sqlSelecionarTodasLocacoesConcluidas, ConverterEmRegistro);
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlSelecionarTodasLocacoesConcluidas);
                throw ex;
            }
        }

        public List<Locacao> SelecionarTodasLocacoesPendentes()
        {
            try
            {
                return Db.GetAll(sqlSelecionarTodasLocacoesPendentes, ConverterEmRegistro);
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlQuery", sqlSelecionarTodasLocacoesPendentes);
                throw ex;
            }
        }

        public List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> ObtemParametrosRegistro(Locacao locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("ID_VEICULO", locacao.Veiculo.Id);
            parametros.Add("ID_CLIENTE", locacao.Cliente.Id);
            parametros.Add("PLANO", locacao.Plano);
            parametros.Add("DATASAIDA", locacao.DataSaida);
            parametros.Add("DATADEVOLUCAO", locacao.DataDevolucao);
            parametros.Add("CAUCAO", locacao.Caucao);
            parametros.Add("CONDUTOR", locacao.Condutor);
            parametros.Add("DEVOLUCAO", "Pendente");

            return parametros;
        }

        public Locacao ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            int idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);
            int idCliente = Convert.ToInt32(reader["ID_CLIENTE"]);
            string condutor = "";
            string plano = Convert.ToString(reader["PLANO"]);
            DateTime dataSaida = Convert.ToDateTime(reader["DATASAIDA"]);
            DateTime dataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
            double caucao = Convert.ToDouble(reader["CAUCAO"]);
            string devolucao = Convert.ToString(reader["DEVOLUCAO"]);

            if (reader["CONDUTOR"] != DBNull.Value)
                condutor = Convert.ToString(reader["CONDUTOR"]);

            Veiculo veiculo = _veiculoRepository.SelecionarPorId(idVeiculo);
            Cliente cliente = _clienteRepository.SelecionarPorId(idCliente);

            List<TaxasServicos> taxas = _taxaRepository.SelecionarTaxasServicosUsados(id);

            List<TaxasServicos> taxasSelecionadas = (taxas.Count == 0) ? null : taxas;

            Locacao locacao = new Locacao(cliente, veiculo, taxasSelecionadas, dataSaida, dataDevolucao,
                caucao, plano, condutor, devolucao);

            locacao.Id = id;

            return locacao;
        }
    }
}
