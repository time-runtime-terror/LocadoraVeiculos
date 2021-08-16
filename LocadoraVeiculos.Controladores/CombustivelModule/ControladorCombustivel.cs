using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.CombustivelModule;

namespace LocadoraVeiculos.Controladores.CombustivelModule
{
    public class ControladorCombustivel
    {

        public string GravarCombustivel(Combustivel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                //salvar os dados dentro do app config
                SalvandoAppConfig("gasolina", Convert.ToString(registro.Gasolina));
                SalvandoAppConfig("etanol", Convert.ToString(registro.Etanol));
                SalvandoAppConfig("diesel", Convert.ToString(registro.Diesel));
                SalvandoAppConfig("gnv", Convert.ToString(registro.Gnv));
            }

            return resultadoValidacao;
        }

        private static void SalvandoAppConfig(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string PegarValorGasolina()
        {
            return ConfigurationManager.AppSettings["gasolina"];
        }

        public static string PegarValorEtanol()
        {
            return ConfigurationManager.AppSettings["etanol"];
        }

        public static string PegarValorDiesel()
        {
            return ConfigurationManager.AppSettings["diesel"];
        }

        public static string PegarValorGnv()
        {
            return ConfigurationManager.AppSettings["gnv"];
        }
    }
}
