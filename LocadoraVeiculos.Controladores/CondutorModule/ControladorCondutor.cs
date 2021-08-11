using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Dominio.CondutorModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.CondutorModule
{
    public class ControladorCondutor : Controlador<Condutor>
    {
        #region Queries
        private const string sqlInserirCondutor =
            @"INSERT INTO TBCONDUTOR 
	                (
		                [NOME], 
		                [CPF],
                        [CNH], 
		                [RG],
		                [VENCIMENTOCNH]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @CPF,
                        @CNH,
		                @RG, 
		                @VENCIMENTOCNH
	                )";

        private const string sqlEditarCondutor =
            @"UPDATE TBCONDUTOR
                    SET
                        [NOME] = @NOME,
                        [CPF] = @CPF,
                        [CNH] = @CNH,
                        [RG] = @RG,
                        [VENCIMENTOCNH] = @DATAVENCIMENTOCNH,
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirCondutor =
            @"DELETE 
	                FROM
                        TBCONDUTOR
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarCondutorPorId =
            @"SELECT
                        [ID],
		                [NOME], 
                        [CPF], 
		                [CNH],
		                [RG],
		                [VENCIMENTOCNH]
	                FROM
                        [TBCONDUTOR] 
                    WHERE 
                        [ID] = @ID";

        private const string sqlSelecionarTodosCondutores =
            @"SELECT
                        [ID],
		                [NOME], 
                        [CPF], 
		                [CNH],
		                [RG],
		                [VENCIMENTOCNH]
	                FROM
                        [TBCONDUTOR] 
                    WHERE 
                        [ID] = @ID";


        private const string sqlExisteCondutor =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCONDUTOR]
            WHERE 
                [ID] = @ID";
        #endregion

        public override string InserirNovo(Condutor registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }
        public override string Editar(int id, Condutor registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCondutor, ObtemParametrosCondutor(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirCondutor, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteCondutor, AdicionarParametro("ID", id));
        }

        public override Condutor SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarCondutorPorId, ConverterEmCondutor, AdicionarParametro("ID", id));
        }

        public override List<Condutor> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosCondutores, ConverterEmCondutor);
        }

        private Dictionary<string, object> ObtemParametrosCondutor(Condutor condutor)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", condutor.Id);
            parametros.Add("NOME", condutor.Nome);
            parametros.Add("CPF", condutor.CPF);
            parametros.Add("CNH", condutor.CNH);
            parametros.Add("RG", condutor.RG);
            parametros.Add("VENCIMENTOCNH", condutor.VencimentoCnh);

            return parametros;
        }

        private Condutor ConverterEmCondutor(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string cnh = Convert.ToString(reader["CNH"]);
            string cpf = Convert.ToString(reader["CPF"]);
            string rg = Convert.ToString(reader["RG"]);
            DateTime vencimentoCnh = Convert.ToDateTime(reader["VENCIMENTOCNH"]);

            Condutor condutor = new Condutor(nome, cnh, cpf, rg, vencimentoCnh);

            condutor.Id = id;

            return condutor;
        }
    }
}
