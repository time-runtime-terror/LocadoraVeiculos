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
                string gasolina = Convert.ToString(registro.Gasolina);
                SalvandoAppConfig("gasolina", gasolina);
                SalvandoAppConfig("etanol", Convert.ToString(registro.Etanol));
                SalvandoAppConfig("diesel", Convert.ToString(registro.Diesel));
                SalvandoAppConfig("gnv", Convert.ToString(registro.Gnv));
            }

            return resultadoValidacao;
        }

        
        public string PegarValorGasolina()
        {
            return ConfigurationManager.AppSettings["gasolina"];
        }

        public string PegarValorEtanol()
        {
            return ConfigurationManager.AppSettings["etanol"];
        }

        public  string PegarValorDiesel()
        {
            return ConfigurationManager.AppSettings["diesel"];
        }

        public  string PegarValorGnv()
        {
            return ConfigurationManager.AppSettings["gnv"];
        }

        private static void SalvandoAppConfig(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
