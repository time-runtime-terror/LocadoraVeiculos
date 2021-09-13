using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Text.Json;
using System;
using System.IO;

namespace LocadoraVeiculos.netCore.Controladores.CombustivelModule
{
    public class ControladorCombustivel
    {
        private Combustivel Combustivel;
        private string ArquivoJson { get; set; }
        private static string Caminho { get; set; }

        public ControladorCombustivel()
        {
            Caminho = $"{Directory.GetCurrentDirectory()}\\configCombustivel.json";

            Combustivel template = new Combustivel(0, 0, 0, 0);

            if (!File.Exists(Caminho))
                SalvarConfiguracoes(template);

            ArquivoJson = File.ReadAllText(Caminho);
        }

        public string GravarCombustivel(Combustivel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                SalvarConfiguracoes(registro);

            return resultadoValidacao;
        }

        private static void SalvarConfiguracoes(Combustivel registro)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(registro, options);

            File.WriteAllText(Caminho, json);
        }

        public string PegarValorGasolina()
        {
            Combustivel = JsonSerializer.Deserialize<Combustivel>(ArquivoJson);
            return Combustivel.Gasolina.ToString();
        }

        public string PegarValorEtanol()
        {
            Combustivel = JsonSerializer.Deserialize<Combustivel>(ArquivoJson);
            return Combustivel.Etanol.ToString();
        }

        public string PegarValorDiesel()
        {
            Combustivel = JsonSerializer.Deserialize<Combustivel>(ArquivoJson);
            return Combustivel.Diesel.ToString();
        }

        public string PegarValorGnv()
        {
            Combustivel = JsonSerializer.Deserialize<Combustivel>(ArquivoJson);
            return Combustivel.Gnv.ToString();
        }
    }
}
