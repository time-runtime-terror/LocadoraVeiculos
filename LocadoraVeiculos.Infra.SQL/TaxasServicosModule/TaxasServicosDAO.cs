using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.netCore.Controladores.Shared;
using LocadoraVeiculos.netCore.Dominio.FuncionarioModule;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.SQL.TaxasServicosModule
{
    public class TaxasServicosDAO : BaseDAO, ITaxasServicosRepository
    {

        #region Queries
        private const string sqlInserirTaxasServicos =
            @"INSERT INTO TBTAXASSERVICOS
	                (
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO],
                        [LOCALSERVICO]
	                ) 
	                VALUES
	                (
                        @SERVICO, 
                        @TAXA,
                        @OPCAOSERVICO, 
                        @LOCALSERVICO
	                )";

        private const string sqlInserirTaxasServicosUsados =
            @"INSERT INTO TBTAXASSERVICOS_USADOS
	                (
		                [ID_TAXASSERVICOS], 
		                [ID_LOCACAO]
	                ) 
	                VALUES
	                (
                        @ID_TAXASSERVICOS, 
                        @ID_LOCACAO
	                )";

        private const string sqlEditarTaxasServicos =
            @"UPDATE TBTAXASSERVICOS
                    SET
                        [SERVICO] = @SERVICO,
		                [TAXA] = @TAXA, 
		                [OPCAOSERVICO] = @OPCAOSERVICO,
                        [LOCALSERVICO] = @LOCALSERVICO

                    WHERE 
                        ID = @ID";

        private const string sqlEditarTaxasServicosUsados =
            @"UPDATE TBTAXASSERVICOS_USADOS
                    SET
                        [ID_TAXASSERVICOS] = @ID_TAXASSERVICOS,
		                [ID_LOCACAO] = @ID_LOCACAO
                    WHERE 
                        [ID_TAXASSERVICOS]= @ID_TAXASSERVICOS";


        private const string sqlExcluirTaxasServicos =
            @"DELETE 
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirTaxasServicosUsados =
            @"DELETE 
	                FROM
                        TBTAXASSERVICOS_USADOS
                    WHERE 
                        ID_LOCACAO = @ID";

        private const string sqlSelecionarTaxasServicosPorId =
            @"SELECT
                        [ID],
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO], 
                        [LOCALSERVICO]
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";


        private const string sqlSelecionarTodasTaxasServicos =
            @"SELECT
                        [ID],
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO],
                        [LOCALSERVICO]
	                FROM
                        TBTAXASSERVICOS";

        private const string sqlSelecionarTaxasServicosUsados =
            @"SELECT
                [ID],
                [ID_TAXASSERVICOS],
                [ID_LOCACAO]
            FROM
                [TBTAXASSERVICOS_USADOS]
            WHERE
                [ID_LOCACAO] = @ID";


        private const string sqlExisteTaxasServicos =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAXASSERVICOS]
            WHERE 
                [ID] = @ID";
        #endregion

        public void InserirNovo(TaxasServicos registro)
        {
            registro.Id = Db.Insert(sqlInserirTaxasServicos, ObtemParametrosRegistro(registro));
        }

        public void InserirNovaTaxaUsada(Locacao registro)
        {
            foreach (TaxasServicos taxa in registro.Taxas)
                Db.Insert(sqlInserirTaxasServicosUsados, ObtemParametrosTaxasServicosUsados(registro, taxa));
        }

        public void Editar(int id, TaxasServicos registro)
        {
            registro.Id = id;
            Db.Update(sqlEditarTaxasServicos, ObtemParametrosRegistro(registro));
        }

        public void EditarTaxasUsadas(Locacao locacao)
        {
            foreach (TaxasServicos taxa in locacao.Taxas)
                Db.Update(sqlEditarTaxasServicosUsados, ObtemParametrosTaxasServicosUsados(locacao, taxa));
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirTaxasServicos, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool ExcluirTaxaUsada(Locacao locacao)
        {
            try
            {
                Db.Delete(sqlExcluirTaxasServicosUsados, AdicionarParametro("ID", locacao.Id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxasServicos, AdicionarParametro("ID", id));
        }

        public TaxasServicos SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTaxasServicosPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }

        public IList<TaxasServicos> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasTaxasServicos, ConverterEmRegistro);
        }

        public List<TaxasServicos> SelecionarTaxasServicosUsados(int id)
        {
            return Db.GetAll(sqlSelecionarTaxasServicosUsados, ConverterEmTaxasServicosUsados, AdicionarParametro("ID", id));
        }

        public Dictionary<string, object> ObtemParametrosRegistro(TaxasServicos taxasServicos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxasServicos.Id);
            parametros.Add("SERVICO", taxasServicos.Servico);
            parametros.Add("TAXA", taxasServicos.Taxa);
            parametros.Add("OPCAOSERVICO", taxasServicos.OpcaoServico);
            parametros.Add("LOCALSERVICO", taxasServicos.LocalServico);

            return parametros;
        }

        public Dictionary<string, object> ObtemParametrosTaxasServicosUsados(Locacao locacao, TaxasServicos taxa)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID_TAXASSERVICOS", taxa.Id);
            parametros.Add("ID_LOCACAO", locacao.Id);

            return parametros;
        }

        public TaxasServicos ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string servico = Convert.ToString(reader["SERVICO"]);
            double taxa = Convert.ToDouble(reader["TAXA"]);
            string opcaoServico = Convert.ToString(reader["OPCAOSERVICO"]);
            string localServico = Convert.ToString(reader["LOCALSERVICO"]);

            TaxasServicos taxasServicos = new TaxasServicos(servico, taxa, opcaoServico, localServico);

            taxasServicos.Id = id;

            return taxasServicos;
        }

        public TaxasServicos ConverterEmTaxasServicosUsados(IDataReader reader)
        {
            if (reader["ID_TAXASSERVICOS"] == DBNull.Value)
                return null;

            return SelecionarPorId(Convert.ToInt32(reader["ID_TAXASSERVICOS"]));
        }

        public IList<TaxasServicos> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }

}
