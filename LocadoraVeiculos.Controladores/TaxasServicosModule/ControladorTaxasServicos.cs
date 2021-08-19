using LocadoraVeiculos.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using LocadoraVeiculos.Dominio.TaxasServicosModule;

namespace LocadoraVeiculos.Controladores.TaxasServicosModule
{
    public class ControladorTaxasServicos : Controlador<TaxasServicos>
    {
        #region Queries
        private const string sqlInserirTaxasServicos =
            @"INSERT INTO TBTAXASSERVICOS
	                (
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO]
	                ) 
	                VALUES
	                (
                        @SERVICO, 
                        @TAXA,
                        @OPCAOSERVICO
	                )";

        private const string sqlEditarTaxasServicos =
            @"UPDATE TBTAXASSERVICOS
                    SET
                        [SERVICO] = @SERVICO,
		                [TAXA] = @TAXA, 
		                [OPCAOSERVICO] = @OPCAOSERVICO

                    WHERE 
                        ID = @ID";

        private const string sqlExcluirTaxasServicos =
            @"DELETE 
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTaxasServicosPorId =
            @"SELECT
                        [ID],
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO]
	                FROM
                        TBTAXASSERVICOS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodasTaxasServicos =
            @"SELECT
                        [ID],
		                [SERVICO], 
		                [TAXA], 
		                [OPCAOSERVICO]
	                FROM
                        TBTAXASSERVICOS";

        private const string sqlExisteTaxasServicos =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAXASSERVICOS]
            WHERE 
                [ID] = @ID";
        #endregion

        public override string InserirNovo(TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirTaxasServicos, ObtemParametrosTaxasServicos(registro));
            }

            return resultadoValidacao;
        }
        public override string Editar(int id, TaxasServicos registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarTaxasServicos, ObtemParametrosTaxasServicos(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
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

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTaxasServicos, AdicionarParametro("ID", id));
        }

        public override TaxasServicos SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarTaxasServicosPorId, ConverterEmTaxasServicos, AdicionarParametro("ID", id));
        }

        public override List<TaxasServicos> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasTaxasServicos, ConverterEmTaxasServicos);
        }

        private Dictionary<string, object> ObtemParametrosTaxasServicos(TaxasServicos grupoAutomoveis)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoAutomoveis.Id);
            parametros.Add("SERVICO", grupoAutomoveis.Servico);
            parametros.Add("TAXA", grupoAutomoveis.Taxa);
            parametros.Add("OPCAOSERVICO", grupoAutomoveis.OpcaoServico);

            return parametros;
        }

        private TaxasServicos ConverterEmTaxasServicos(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string servico = Convert.ToString(reader["SERVICO"]);
            double taxa = Convert.ToDouble(reader["TAXA"]);
            string opcaoServico = Convert.ToString(reader["OPCAOSERVICO"]);

            TaxasServicos taxasServicos = new TaxasServicos(servico, taxa, opcaoServico);

            taxasServicos.Id = id;

            return taxasServicos;
        }

        public override List<TaxasServicos> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
