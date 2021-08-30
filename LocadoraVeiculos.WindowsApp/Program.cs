using LocadoraVeiculos.Controladores.Shared;
using LocadoraVeiculos.WindowsApp;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp
{
    static class Program
    {
        #region Queries para setup inicial das tabelas

        static string sqlInserirAdmin = 
            @"INSERT INTO TBFUNCIONARIO 
                    (
                        [NOME],
                        [NOMEUSUARIO],
                        [SENHA],
                        [DATAENTRADA],
                        [SALARIO]
                    ) 
                    VALUES
                    (
                        'admin',
                        'admin',
                        'admin',
                        '2015-12-17',
                        '1000'
                    )";

        static string sqlExisteAdmin =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBFUNCIONARIO]
            WHERE 
                [NOMEUSUARIO] = @NOMEUSUARIO";

        static string sqlInserirCliente =
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
                        'Rech', 
                        'Bar do Gordo, 123',
                        '99999999',
		                '3250294', 
		                '1111122222',
                        '111123333',
		                '1111111',
		                '2025-12-31',
		                null
	                )";

        static string sqlExisteCliente =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTE]
            WHERE 
                [NOME] = @NOME";

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
                        'Seguro para Cliente', 
                        70,
                        'Fixo', 
                        'Locação'
	                )";

        static string sqlExisteTaxa =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBTAXASSERVICOS]
            WHERE 
                [SERVICO] = @SERVICO";

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
                        'Popular', 
                        200,
                        10,
		                200, 
		                10,
                        500,
                        100
	                )";

        static string sqlExisteGrupoAutomovel =
        @"SELECT 
                COUNT(*) 
            FROM 
                [TBGRUPOAUTOMOVEIS]
            WHERE 
                [NOMEGRUPO] = @NOMEGRUPO";
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Db.Exists(sqlExisteAdmin, new Dictionary<string, object>() { { "NOMEUSUARIO", "admin" } }))
                Db.Update(sqlInserirAdmin);

            if (!Db.Exists(sqlExisteCliente, new Dictionary<string, object>() { { "NOME", "Rech" } }))
                Db.Update(sqlInserirCliente);

            if (!Db.Exists(sqlExisteTaxa, new Dictionary<string, object>() { { "SERVICO", "Seguro para Cliente" } }))
                Db.Update(sqlInserirTaxasServicos);

            if (!Db.Exists(sqlExisteGrupoAutomovel, new Dictionary<string, object>() { { "NOMEGRUPO", "Popular" } }))
                Db.Update(sqlInserirGrupoAutomoveis);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new TelaCadastrarLocacaoForm());
        }
    }
}
