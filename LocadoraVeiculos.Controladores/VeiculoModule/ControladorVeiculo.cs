using System;
using System.Collections.Generic;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.Controladores.Shared;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;

namespace LocadoraVeiculos.Controladores.VeiculoModule
{
    public class ControladorVeiculo : Controlador<Veiculo>
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
                    VE.[ID_GRUPOAUTOMOVEIS]
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
                    VE.[ID_GRUPOAUTOMOVEIS]
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

        private ControladorGrupoAutomoveis controladorGrupoAutomoveis;

        public ControladorVeiculo()
        {
            controladorGrupoAutomoveis = new ControladorGrupoAutomoveis();
        }

        public override string InserirNovo(Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
            }

            return resultadoValidacao;
        }

        public void AtualizarQuilometragem(Veiculo veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("QUILOMETRAGEM", veiculo.Quilometragem);

            Db.Update(sqlAtualizarQuilometragem, parametros);
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteTarefa, AdicionarParametro("ID", id));
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);
        }

        public override Veiculo SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));
        }

        private Veiculo ConverterEmVeiculo(IDataReader reader)
        {
            var placa = Convert.ToString(reader["PLACA"]);
            byte[] foto = (byte[])reader["FOTO"]; 
            var modelo = Convert.ToString(reader["MODELO"]);
            var marca = Convert.ToString(reader["MARCA"]);
            var tipoCombustivel = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            var capacidadeTanque = Convert.ToInt32(reader["CAPACIDADETANQUE"]);
            var quilometragem = Convert.ToInt32(reader["QUILOMETRAGEM"]);

            GrupoAutomoveis grupo = null;

            if (reader["ID_GRUPOAUTOMOVEIS"] != DBNull.Value)
                grupo = controladorGrupoAutomoveis.SelecionarPorId(Convert.ToInt32(reader["ID_GRUPOAUTOMOVEIS"]));

            Veiculo veiculo = new Veiculo(foto, placa, modelo, marca, tipoCombustivel, capacidadeTanque, quilometragem, grupo);

            veiculo.Id = Convert.ToInt32(reader["ID"]);

            return veiculo;
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Veiculo veiculo)
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

        public override List<Veiculo> Pesquisar(string modelo)
        {
            return Db.GetAll(sqlPesquisarVeiculos, ConverterEmVeiculo, AdicionarParametro("MODELO", modelo + "%"));
        }
    }
}
