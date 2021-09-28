using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;

namespace LocadoraVeiculos.Infra.PDF.LocacaoModule
{
    public class GeradorRecibo : IGeradorRecibo
    {
        public string GerarRecibo(Locacao locacao)
        {
            float posicaoVertical = 300;
            float posicaoHorizontal = 50;

            Document document = new Document();

            Page page = new Page(PageSize.A4, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            string strTitulo = "Recibo de Locação\nLocadora Rech";
            Label titulo = new Label(strTitulo, 0, 120, 504, 100, Font.HelveticaBold, 18, TextAlign.Center);

            page.Elements.Add(titulo);

            string strSubtitulo = $"Seguem os dados da locação feita em nome do cliente: {locacao.Cliente}";
            Label novaLabel = new Label(strSubtitulo, posicaoHorizontal, 240, 400, 100, Font.HelveticaBold, 14, TextAlign.Left);

            page.Elements.Add(novaLabel);

            string[] dadosLocacao = ObtemDadosDaLocacao(locacao);

            for (int i = 0; i < dadosLocacao.Length; i++)
            {
                Label labelPropriedades = new Label(dadosLocacao[i], posicaoHorizontal, posicaoVertical, 504, 100, Font.Helvetica, 12, TextAlign.Left);
                page.Elements.Add(labelPropriedades);

                posicaoVertical += 20;
            }

            if (locacao.Taxas != null)
            {
                posicaoVertical += 30;

                Label taxasAplicadas = new Label("Taxas Aplicadas:", posicaoHorizontal, posicaoVertical, 504, 100, Font.HelveticaBold, 14, TextAlign.Left);

                page.Elements.Add(taxasAplicadas);

                foreach (TaxasServicos taxa in locacao.Taxas)
                {
                    string dadosTaxas = $"{taxa.Servico}\t\tTipo de Serviço: {taxa.OpcaoServico}\t\tR$ {taxa.Taxa}";

                    Label labelTaxa = new Label(dadosTaxas, posicaoHorizontal, posicaoVertical + 20, 504, 100, Font.Helvetica, 12, TextAlign.Left);
                    page.Elements.Add(labelTaxa);

                    posicaoVertical += 20;
                }
            }

            Label total = new Label($"Total: R$ {locacao.Total}", posicaoHorizontal, posicaoVertical + 50, 504, 100, Font.HelveticaBold, 14, TextAlign.Left);
            total.TextColor = RgbColor.ForestGreen;

            page.Elements.Add(total);

            string pastaTemp = System.IO.Path.GetTempPath();

            var dataAtual = System.DateTime.Now.Ticks;

            string nomeArquivo = $"{pastaTemp}reciboLocacao{locacao.Id}-{dataAtual}.pdf";

            document.Draw(nomeArquivo);

            return nomeArquivo;
        }

        #region Métodos privados

        private string[] ObtemDadosDaLocacao(Locacao locacao)
        {
            return new string[]
            {
                $"Veículo: {locacao.Veiculo}",
                $"Condutor: {locacao.Condutor}",
                $"Plano: {locacao.Plano}",
                $"Valor da Caução: R$ {locacao.Caucao}",
                $"Data de Saída: {locacao.DataSaida.ToShortDateString()}",
                $"Data Prevista de Devolução: {locacao.DataDevolucao.ToShortDateString()}",
                $"Data de Devolução: {locacao.Devolucao}"
            };
        }
        #endregion
    }
}
