using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.Controladores.LocacaoModule
{
    public class ControladorLocacao : Controlador<Locacao>
    {
        #region Queries
        private const string sqlInserirLocacao =
            @"INSERT INTO TBCLIENTE 
	                (
		                [NOME], 
		                [ENDERECO], 
		                [TELEFONE], 
		                [TIPOCADASTRO],
                        [NUMEROCADASTRO], 
                        [CNH],
		                [RG],
		                [DATAVENCIMENTOCNH],
		                [ID_EMPRESA]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @ENDERECO,
                        @TELEFONE,
		                @TIPOCADASTRO, 
		                @NUMEROCADASTRO,
                        @CNH,
		                @RG,
		                @DATAVENCIMENTOCNH,
		                @ID_EMPRESA
	                )";

        private const string sqlEditarLocacao =
            @"UPDATE TBCLIENTE
                    SET
                        [NOME] = @NOME,
		                [ENDERECO] = @ENDERECO, 
		                [TELEFONE] = @TELEFONE,
                        [TIPOCADASTRO] = @TIPOCADASTRO,
                        [NUMEROCADASTRO] = @NUMEROCADASTRO,
                        [CNH] = @CNH,
                        [RG] = @RG,
                        [DATAVENCIMENTOCNH] = @DATAVENCIMENTOCNH,
                        [ID_EMPRESA] = @ID_EMPRESA
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirLocacao =
            @"DELETE 
	                FROM
                        TBCLIENTE
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE 
                        CL.[ID] = @ID";

        private const string sqlSelecionarTodasLocacoes =
            @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA";

        private const string sqlExisteLocacao =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBLOCACAO]
            WHERE 
                [ID] = @ID";

        private const string sqlPesquisarLocacoes =
                        @"SELECT
                        CL.[ID],
		                CL.[NOME], 
		                CL.[ENDERECO], 
		                CL.[TELEFONE], 
		                CL.[TIPOCADASTRO],
                        CL.[NUMEROCADASTRO], 
                        CL.[CNH],
		                CL.[RG],
		                CL.[DATAVENCIMENTOCNH],
		                CL.[ID_EMPRESA]
	                FROM
                        [TBCLIENTE] AS CL LEFT JOIN
                        [TBCLIENTE] AS CE
                    ON
                        CE.ID = CL.ID_EMPRESA
                    WHERE
                        CL.[NOME] LIKE @NOME";

        #endregion

        public override string InserirNovo(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public override string Editar(int id, Locacao registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public override List<Locacao> Pesquisar(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
