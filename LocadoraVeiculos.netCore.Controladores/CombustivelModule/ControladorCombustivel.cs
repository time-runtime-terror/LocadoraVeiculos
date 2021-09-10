using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LocadoraVeiculos.netCore.Controladores.CombustivelModule
{
    public class ControladorCombustivel
    {
        static IConfigurationBuilder configuracao;

        static ControladorCombustivel()
        {
            configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }

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
            return configuracao.Build().GetSection("gasolina").Value;
        }

        public string PegarValorEtanol()
        {
            return configuracao.Build().GetSection("etanol").Value;
        }

        public string PegarValorDiesel()
        {
            return configuracao.Build().GetSection("diesel").Value;
        }

        public string PegarValorGnv()
        {
            return configuracao.Build().GetSection("gnv").Value;
        }

        private static void SalvandoAppConfig(string key, string value)
        {
            configuracao.Build().GetSection(key).Value = value;
        }
    }
}
