using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.Shared;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.SQL.VeiculosModule
{
    public class VeiculosDAO : BaseDAO, IVeiculoRepository
    {
        #region Queries
        private const string sqlInserirVeiculo =
            @"INSERT INTO [TBVEICULO]
                (
                    [FOTO],       
                    [PLACA],             
                    [MODELO],                    
                    [MARCA], 
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADETANQUE],
                    [QUILOMETRAGEM],
                    [ID_GRUPOAUTOMOVEIS]
                )
            VALUES
                (
                    @FOTO,
                    @PLACA,
                    @MODELO,
                    @MARCA,
                    @TIPOCOMBUSTIVEL,
                    @CAPACIDADETANQUE,
                    @QUILOMETRAGEM,
                    @ID_GRUPOAUTOMOVEIS
                )";

        private const string sqlEditarVeiculo =
            @" UPDATE [TBVEICULO]
                SET 
                    [FOTO] = @FOTO, 
                    [PLACA] = @PLACA, 
                    [MODELO] = @MODELO, 
                    [MARCA] = @MARCA,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                    [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                    [QUILOMETRAGEM] = @QUILOMETRAGEM,
                    [ID_GRUPOAUTOMOVEIS] = @ID_GRUPOAUTOMOVEIS

                WHERE [ID] = @ID";

        private const string sqlAtualizarQuilometragem =
            @" UPDATE [TBVEICULO]
                SET 
                    [QUILOMETRAGEM] = @QUILOMETRAGEM
                WHERE [ID] = @ID";

        private const string sqlAtualizarStatusAlugado =
            @" UPDATE [TBVEICULO]
                    SET 
                        [ESTA_ALUGADO] = @ESTA_ALUGADO
                    WHERE [ID] = @ID";

        private const string sqlExcluirVeiculo =
            @"DELETE FROM [TBVEICULO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosVeiculos =
            @"SELECT 
                    VE.[ID],       
                    VE.[FOTO],       
                    VE.[PLACA],             
                    VE.[MODELO],                    
                    VE.[MARCA], 
                    VE.[TIPOCOMBUSTIVEL],
                    VE.[CAPACIDADETANQUE],
                    VE.[QUILOMETRAGEM],
                    VE.[ID_GRUPOAUTOMOVEIS],
                    VE.[ESTA_ALUGADO]
            FROM
                    [TBVEICULO] AS VE LEFT JOIN
                    [TBGRUPOAUTOMOVEIS] AS GA
            ON
                    GA.ID = VE.[ID_GRUPOAUTOMOVEIS]";

        private const string sqlSelecionarVeiculoPorId =
           @"SELECT 
                    VE.[ID],       
                    VE.[FOTO],       
                    VE.[PLACA],             
                    VE.[MODELO],                    
                    VE.[MARCA], 
                    VE.[TIPOCOMBUSTIVEL],
                    VE.[CAPACIDADETANQUE],
                    VE.[QUILOMETRAGEM],
                    VE.[ID_GRUPOAUTOMOVEIS],
                    VE.[ESTA_ALUGADO]
            FROM
                    [TBVEICULO] AS VE LEFT JOIN
                    [TBGRUPOAUTOMOVEIS] AS GA
            ON
                    GA.ID = VE.[ID_GRUPOAUTOMOVEIS]
            WHERE
                    VE.[ID] = @ID";

        private const string sqlExisteTarefa =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULO]
            WHERE 
                [ID] = @ID";

        private const string sqlPesquisarVeiculos =
            @"SELECT 
                    VE.[ID],       
                    VE.[FOTO],       
                    VE.[PLACA],             
                    VE.[MODELO],                    
                    VE.[MARCA], 
                    VE.[TIPOCOMBUSTIVEL],
                    VE.[CAPACIDADETANQUE],
                    VE.[QUILOMETRAGEM],
                    VE.[ID_GRUPOAUTOMOVEIS]
            FROM
                    [TBVEICULO] AS VE LEFT JOIN
                    [TBGRUPOAUTOMOVEIS] AS GA
            ON
                    GA.ID = VE.[ID_GRUPOAUTOMOVEIS]
            WHERE
                    VE.[MODELO] LIKE @MODELO";
        #endregion

        private readonly IGrupoAutomoveisRepository grupoAutomoveisRepository;

        public VeiculosDAO(IGrupoAutomoveisRepository grupoAutomoveisRepository)
        {
            this.grupoAutomoveisRepository = grupoAutomoveisRepository;
        }

        public void InserirNovo(Veiculo registro)
        {                 
            try
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosRegistro(registro));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlInserirVeiculo", sqlInserirVeiculo);
                throw ex;
            }
        }

        public void Editar(int id, Veiculo registro)
        {
            registro.Id = id;

            try
            {
                Db.Update(sqlEditarVeiculo, ObtemParametrosRegistro(registro));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlEditarVeiculo", sqlEditarVeiculo);
                ex.Data.Add("idVeiculo", id);
                throw ex;
            }
        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("QUILOMETRAGEM", veiculo.Quilometragem);

            Db.Update(sqlAtualizarQuilometragem, parametros);
        }
        public void AtualizarStatusAluguel(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("ESTA_ALUGADO", veiculo.EstaAlugado);

            Db.Update(sqlAtualizarStatusAlugado, parametros);
        }

        public bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlExcluirVeiculo", sqlExcluirVeiculo);
                ex.Data.Add("idVeiculo", id);
                throw ex;
            }

            return true;
        }

        public bool Existe(int id)
        {            
            try
            {
                return Db.Exists(sqlExisteTarefa, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlExisteTarefa", sqlExisteTarefa);
                ex.Data.Add("idVeiculo", id);
                throw ex;
            }
        }

        public List<Veiculo> SelecionarTodos()
        {            
            try
            {
                return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmRegistro);
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlSelecionarTodosVeiculos", sqlSelecionarTodosVeiculos);
                throw ex;
            }
        }

        public Veiculo SelecionarPorId(int id)
        {            
            try
            {
                return Db.Get(sqlSelecionarVeiculoPorId, ConverterEmRegistro, AdicionarParametro("ID", id));
            }
            catch (Exception ex)
            {
                ex.Data.Add("sqlSelecionarVeiculoPorId", sqlSelecionarVeiculoPorId);
                ex.Data.Add("idVeiculo", id);
                throw ex;
            }
        }

        public List<Veiculo> Pesquisar(string modelo)
        {
            return Db.GetAll(sqlPesquisarVeiculos, ConverterEmRegistro, AdicionarParametro("MODELO", modelo + "%"));
        }

        public Veiculo ConverterEmRegistro(IDataReader reader)
        {
            var placa = Convert.ToString(reader["PLACA"]);
            byte[] foto = (byte[])reader["FOTO"];
            var modelo = Convert.ToString(reader["MODELO"]);
            var marca = Convert.ToString(reader["MARCA"]);
            var tipoCombustivel = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            var capacidadeTanque = Convert.ToInt32(reader["CAPACIDADETANQUE"]);
            var quilometragem = Convert.ToInt32(reader["QUILOMETRAGEM"]);


            bool estaAlugado = false;

            if (reader["ESTA_ALUGADO"] != DBNull.Value)
                estaAlugado = Convert.ToBoolean(reader["ESTA_ALUGADO"]);

            GrupoAutomoveis grupo = null;

            if (reader["ID_GRUPOAUTOMOVEIS"] != DBNull.Value)
                grupo =
                    grupoAutomoveisRepository.SelecionarPorId(Convert.ToInt32(reader["ID_GRUPOAUTOMOVEIS"]));

            Veiculo veiculo = new Veiculo(foto, placa, modelo, marca, tipoCombustivel, capacidadeTanque, quilometragem, grupo);

            veiculo.Id = Convert.ToInt32(reader["ID"]);
            veiculo.EstaAlugado = estaAlugado;

            return veiculo;
        }

        public Dictionary<string, object> ObtemParametrosRegistro(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("FOTO", veiculo.Foto);
            parametros.Add("PLACA", veiculo.Placa);
            parametros.Add("MODELO", veiculo.Modelo);
            parametros.Add("MARCA", veiculo.Marca);
            parametros.Add("TIPOCOMBUSTIVEL", veiculo.TipoCombustivel);
            parametros.Add("CAPACIDADETANQUE", veiculo.CapacidadeTanque);
            parametros.Add("QUILOMETRAGEM", veiculo.Quilometragem);

            var idGrupoAutomoveis = veiculo.GrupoAutomoveis?.Id;

            parametros.Add("ID_GRUPOAUTOMOVEIS", idGrupoAutomoveis);

            return parametros;
        }
    }
}
