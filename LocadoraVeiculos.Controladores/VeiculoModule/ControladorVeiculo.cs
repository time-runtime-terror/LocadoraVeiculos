using System;
using System.Collections.Generic;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.Controladores.Shared;
using System.Data;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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
                    [TIPOVEICULO]
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
                    @TIPOVEICULO
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
                    [TIPOVEICULO] = @TIPOVEICULO

                WHERE [ID] = @ID";

        private const string sqlExcluirVeiculo =
            @"DELETE FROM [TBVEICULO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosVeiculos =
            @"SELECT 
                    [ID],       
                    [FOTO],       
                    [PLACA],             
                    [MODELO],                    
                    [MARCA], 
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADETANQUE],
                    [QUILOMETRAGEM],
                    [TIPOVEICULO]
            FROM
                [TBVEICULO]";

        private const string sqlSelecionarVeiculoPorId =
            @"SELECT 
                    [ID],       
                    [FOTO],       
                    [PLACA],             
                    [MODELO],                    
                    [MARCA], 
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADETANQUE],
                    [QUILOMETRAGEM],
                    [TIPOVEICULO]
             FROM
                [TBVEICULO]
             WHERE 
                [ID] = @ID";

        private const string sqlExisteTarefa =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULO]
            WHERE 
                [ID] = @ID";

        #endregion

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
            var capacidadeTanque = Convert.ToString(reader["CAPACIDADETANQUE"]);
            var quilometragem = Convert.ToString(reader["QUILOMETRAGEM"]);
            var tipoVeiculo = Convert.ToString(reader["TIPOVEICULO"]);

            Veiculo veiculo = new Veiculo(foto, placa, modelo, marca, tipoCombustivel, capacidadeTanque, quilometragem, tipoVeiculo);

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
            parametros.Add("TIPOVEICULO", veiculo.TipoVeiculo);

            return parametros;
        }
    }
}
