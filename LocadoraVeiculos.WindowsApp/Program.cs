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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Db.Exists(sqlExisteAdmin, new Dictionary<string, object>() { { "NOMEUSUARIO", "admin" } }))
                Db.Update(sqlInserirAdmin);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            Application.Run(new TelaCadastrarLocacaoForm());
        }
    }
}
