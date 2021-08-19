using System;
using System.Collections.Generic;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.Controladores.Shared;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LocadoraVeiculos.Controladores.GrupoAutomoveisModule
{
    public class ControladorGrupoAutomoveis : Controlador<GrupoAutomoveis>
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
                        [KMLIVREUM]
	                ) 
	                VALUES
	                (
                        @NOMEGRUPO, 
                        @PLANODIARIOUM,
                        @PLANODIARIODOIS,
		                @KMCONTROLADOUM, 
		                @KMCONTROLADODOIS,
                        @KMLIVREUM
	                )";

        private const string sqlEditarGrupoAutomoveis =
            @"UPDATE TBGRUPOAUTOMOVEIS
                    SET
                        [NOMEGRUPO] = @NOMEGRUPO,
		                [PLANODIARIOUM] = @PLANODIARIOUM, 
		                [PLANODIARIODOIS] = @PLANODIARIODOIS,
                        [KMCONTROLADOUM] = @KMCONTROLADOUM,
                        [KMCONTROLADODOIS] = @KMCONTROLADODOIS,
                        [KMLIVREUM] = @KMLIVREUM

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
                        [KMLIVREUM]
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
                        [KMLIVREUM]
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

        public override string InserirNovo(GrupoAutomoveis registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirGrupoAutomoveis, ObtemParametrosGrupoAutomoveis(registro));
            }

            return resultadoValidacao;
        }
        public override string Editar(int id, GrupoAutomoveis registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarGrupoAutomoveis, ObtemParametrosGrupoAutomoveis(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirGrupoAutomoveis, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteGrupoAutomoveis, AdicionarParametro("ID", id));
        }

        public override GrupoAutomoveis SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarGrupoAutomoveisPorId, ConverterEmGrupoAutomovel, AdicionarParametro("ID", id));
        }

        public override List<GrupoAutomoveis> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosGruposAutomoveis, ConverterEmGrupoAutomovel);
        }

        private Dictionary<string, object> ObtemParametrosGrupoAutomoveis(GrupoAutomoveis grupoAutomoveis)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoAutomoveis.Id);
            parametros.Add("NOMEGRUPO", grupoAutomoveis.NomeGrupo);
            parametros.Add("PLANODIARIOUM", grupoAutomoveis.PlanoDiarioUm);
            parametros.Add("PLANODIARIODOIS", grupoAutomoveis.PlanoDiarioDois);
            parametros.Add("KMCONTROLADOUM", grupoAutomoveis.KmControladoUm);
            parametros.Add("KMCONTROLADODOIS", grupoAutomoveis.KmControladoDois);
            parametros.Add("KMLIVREUM", grupoAutomoveis.KmLivreUm);

            return parametros;
        }

        private GrupoAutomoveis ConverterEmGrupoAutomovel(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nomeGrupo = Convert.ToString(reader["NOMEGRUPO"]);
            double planoDiarioUm = Convert.ToDouble(reader["PLANODIARIOUM"]);
            double planoDiarioDois = Convert.ToDouble(reader["PLANODIARIODOIS"]);
            double kmControladoUm = Convert.ToDouble(reader["KMCONTROLADOUM"]);
            double kmControladoDois = Convert.ToDouble(reader["KMCONTROLADODOIS"]);
            double kmLivreUm = Convert.ToDouble(reader["KMLIVREUM"]);

            GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis(nomeGrupo, planoDiarioUm, planoDiarioDois, kmControladoUm,
                kmControladoDois, kmLivreUm);

            grupoAutomoveis.Id = id;

            return grupoAutomoveis;
        }

        public override List<GrupoAutomoveis> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
