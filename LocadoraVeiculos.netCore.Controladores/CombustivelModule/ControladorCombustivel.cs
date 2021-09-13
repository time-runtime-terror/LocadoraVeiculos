using LocadoraVeiculos.netCore.Dominio.CombustivelModule;
using System.Text.Json;
using System.IO;

namespace LocadoraVeiculos.netCore.Controladores.CombustivelModule
{
    public class ControladorCombustivel
    {
        private Combustivel Combustivel;
        private string ArquivoJson { get; set; }
        private string Caminho { get; set; }

        public ControladorCombustivel()
        {
            Caminho = $"{Directory.GetCurrentDirectory()}\\configCombustivel.json";

            if (!File.Exists(Caminho))
                SalvarConfiguracoes(new Combustivel(0, 0, 0, 0));

            ArquivoJson = File.ReadAllText(Caminho);
        }

        public string GravarCombustivel(Combustivel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
                SalvarConfiguracoes(registro);

            return resultadoValidacao;
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

        private void SalvarConfiguracoes(Combustivel registro)
        {
            JsonSerializerOptions opcoesSerializacao 
                = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(registro, opcoesSerializacao);

            File.WriteAllText(Caminho, json);
        }
    }
}
