using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule
{
    public class GrupoAutomoveisDAO : BaseDAO, IGrupoAutomoveisRepository
    {
        #region Queries
        private const string sqlInserirGrupoAutomoveis =
            @"INSERT INTO TBGRUPOAUTOMOVEIS 
	                (
		                [NOMEGRUPO], 
		                [PLANODIARIOUM], 
		                [PLANODIARIODOIS],
                        [KMCONTROLADOUM], 
		                [KMCONTROLADODOIS],
                        [KMLIVREUM],
                        [KMCONTROLADOINCLUIDO]
	                ) 
	                VALUES
	                (
                        @NOMEGRUPO, 
                        @PLANODIARIOUM,
                        @PLANODIARIODOIS,
		                @KMCONTROLADOUM, 
		                @KMCONTROLADODOIS,
                        @KMLIVREUM,
                        @KMCONTROLADOINCLUIDO
	                )";

        private const string sqlEditarGrupoAutomoveis =
            @"UPDATE TBGRUPOAUTOMOVEIS
                    SET
                        [NOMEGRUPO] = @NOMEGRUPO,
		                [PLANODIARIOUM] = @PLANODIARIOUM, 
		                [PLANODIARIODOIS] = @PLANODIARIODOIS,
                        [KMCONTROLADOUM] = @KMCONTROLADOUM,
                        [KMCONTROLADODOIS] = @KMCONTROLADODOIS,
                        [KMLIVREUM] = @KMLIVREUM,
                        [KMCONTROLADOINCLUIDO] = @KMCONTROLADOINCLUIDO

                    WHERE 
                        ID = @ID";

        private const string sqlExcluirGrupoAutomoveis =
            @"DELETE 
	                FROM
                        TBGRUPOAUTOMOVEIS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarGrupoAutomoveisPorId =
            @"SELECT
                        [ID],
		                [NOMEGRUPO], 
		                [PLANODIARIOUM], 
		                [PLANODIARIODOIS],
                        [KMCONTROLADOUM], 
		                [KMCONTROLADODOIS],
                        [KMLIVREUM],
                        [KMCONTROLADOINCLUIDO]
	                FROM
                        TBGRUPOAUTOMOVEIS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosGruposAutomoveis =
            @"SELECT
                        [ID],
		                [NOMEGRUPO], 
		                [PLANODIARIOUM], 
		                [PLANODIARIODOIS],
                        [KMCONTROLADOUM], 
		                [KMCONTROLADODOIS],
                        [KMLIVREUM],
                        [KMCONTROLADOINCLUIDO]
	                FROM
                        TBGRUPOAUTOMOVEIS";

        private const string sqlExisteGrupoAutomoveis =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBGRUPOAUTOMOVEIS]
            WHERE 
                [ID] = @ID";
        #endregion

        public void InserirNovo(GrupoAutomoveis registro)
        {
            try
            {
                registro.Id = Db.Insert(sqlInserirGrupoAutomoveis, ObtemParametrosRegistro(registro));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlInserirGrupoAutomoveis", sqlInserirGrupoAutomoveis);
                throw ex;
            }
        }

        public void Editar(int id, GrupoAutomoveis registro)
        {
            registro.Id = id;
            try
            {
                Db.Update(sqlEditarGrupoAutomoveis, ObtemParametrosRegistro(registro));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlEditarGrupoAutomoveis", sqlEditarGrupoAutomoveis);
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirGrupoAutomoveis, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlExcluirGrupoAutomoveis", sqlExcluirGrupoAutomoveis);
                throw ex;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                return Db.Exists(sqlExisteGrupoAutomoveis, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlExisteGrupoAutomoveis", sqlExisteGrupoAutomoveis);
                throw ex;
            }
        }

        public GrupoAutomoveis SelecionarPorId(int id)
        {
            try
            {
                return Db.Get(sqlSelecionarGrupoAutomoveisPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlSelecionarGrupoAutomoveisPorId", sqlSelecionarGrupoAutomoveisPorId);
                throw ex;
            }
        }

        public List<GrupoAutomoveis> SelecionarTodos()
        {
            try
            {
                return Db.GetAll(sqlSelecionarTodosGruposAutomoveis, ConverterEmRegistro);
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlSelecionarTodosGruposAutomoveis", sqlSelecionarTodosGruposAutomoveis);
                throw ex;
            }
        }

        public List<GrupoAutomoveis> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> ObtemParametrosRegistro(GrupoAutomoveis grupoAutomoveis)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoAutomoveis.Id);
            parametros.Add("NOMEGRUPO", grupoAutomoveis.NomeGrupo);
            parametros.Add("PLANODIARIOUM", grupoAutomoveis.PlanoDiarioUm);
            parametros.Add("PLANODIARIODOIS", grupoAutomoveis.PlanoDiarioDois);
            parametros.Add("KMCONTROLADOUM", grupoAutomoveis.KmControladoUm);
            parametros.Add("KMCONTROLADODOIS", grupoAutomoveis.KmControladoDois);
            parametros.Add("KMLIVREUM", grupoAutomoveis.KmLivreUm);
            parametros.Add("KMCONTROLADOINCLUIDO", grupoAutomoveis.KmControladoIncluida);

            return parametros;
        }

        public GrupoAutomoveis ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nomeGrupo = Convert.ToString(reader["NOMEGRUPO"]);
            double planoDiarioUm = Convert.ToDouble(reader["PLANODIARIOUM"]);
            double planoDiarioDois = Convert.ToDouble(reader["PLANODIARIODOIS"]);
            double kmControladoUm = Convert.ToDouble(reader["KMCONTROLADOUM"]);
            double kmControladoDois = Convert.ToDouble(reader["KMCONTROLADODOIS"]);
            double kmLivreUm = Convert.ToDouble(reader["KMLIVREUM"]);
            double kmControladoIncluida = Convert.ToDouble(reader["KMCONTROLADOINCLUIDO"]);

            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis(nomeGrupo, planoDiarioUm, planoDiarioDois, kmControladoUm,
                kmControladoDois, kmLivreUm, kmControladoIncluida);

            grupoAutomoveis.Id = id;

            return grupoAutomoveis;
        }

    }
}
