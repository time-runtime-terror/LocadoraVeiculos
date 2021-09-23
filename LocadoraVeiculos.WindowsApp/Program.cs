using LocadoraVeiculos.Infra.Logging;
using LocadoraVeiculos.netCore.Infra.SQL.Shared;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
		                [ID_EMPRESA],
                        [EMAIL]
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
		                null,
                        'lucas@gmail.com'
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
            ObterLoginAdmin();

            ObterPrimeiroCliente();

            ObterPrimeiraTaxa();

            ObterPrimeiroGrupoAutomoveis();

            LoggerInit.ConfigurarLogger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        #region Métodos de setup inicial das tabelas

        private static bool ExistePrimeiroGrupoAutomoveis()
        {
            return Db.Exists(sqlExisteGrupoAutomovel, new Dictionary<string, object>() { { "NOMEGRUPO", "Popular" } });
        }

        private static void ObterPrimeiroGrupoAutomoveis()
        {
            if (!ExistePrimeiroGrupoAutomoveis())
                Db.Update(sqlInserirGrupoAutomoveis);
        }

        private static bool ExistePrimeiraTaxa()
        {
            return Db.Exists(sqlExisteTaxa, new Dictionary<string, object>() { { "SERVICO", "Seguro para Cliente" } });
        }

        private static void ObterPrimeiraTaxa()
        {
            if (!ExistePrimeiraTaxa())
                Db.Update(sqlInserirTaxasServicos);
        }

        private static bool ExistePrimeiroCliente()
        {
            return Db.Exists(sqlExisteCliente, new Dictionary<string, object>() { { "NOME", "Rech" } });
        }

        private static void ObterPrimeiroCliente()
        {
            if (!ExistePrimeiroCliente())
                Db.Update(sqlInserirCliente);
        }

        private static bool ExisteAdmin()
        {
            return Db.Exists(sqlExisteAdmin, new Dictionary<string, object>() { { "NOMEUSUARIO", "admin" } });
        }

        private static void ObterLoginAdmin()
        {
            if (!ExisteAdmin())
                Db.Update(sqlInserirAdmin);
        }

        #endregion
    }
}
