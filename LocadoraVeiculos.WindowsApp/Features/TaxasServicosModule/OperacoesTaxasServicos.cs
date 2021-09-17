using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public class OperacoesTaxasServicos : ICadastravel
    {
        private readonly TaxasServicosAppService taxasServicosAppService = null;
        private readonly TabelaTaxasServicosControl tabelaTaxasServicos = null;

        public OperacoesTaxasServicos(TaxasServicosAppService taxasServicosAppService)
        {
            this.taxasServicosAppService = taxasServicosAppService;
            tabelaTaxasServicos = new TabelaTaxasServicosControl(taxasServicosAppService);
        }

        public void InserirNovoRegistro()
        {

            TelaCadastrarTaxasServicos tela = new TelaCadastrarTaxasServicos();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasServicosAppService.RegistrarNovaTaxa(tela.TaxasServicos);

                tabelaTaxasServicos.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaTaxasServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um serviço para Editar!!", "Edição de Taxas e Serviços",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxasServicos taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);

            TelaCadastrarTaxasServicos tela = new TelaCadastrarTaxasServicos();

            tela.TaxasServicos = taxasServicosSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                taxasServicosAppService.Editar(id, tela.TaxasServicos);

                tabelaTaxasServicos.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaTaxasServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Serviço para excluir!!", "Exclusão de Taxas e Serviços",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxasServicos taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir esse Serviço?: [{taxasServicosSelecionado.Servico}] ?",
                "Exclusão de Taxas e Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                taxasServicosAppService.Excluir(id);

                tabelaTaxasServicos.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{taxasServicosSelecionado.Servico}] removido com sucesso");
            }
        }

        public void AgruparRegistros()
        {
            
        }
        public void FiltrarRegistros()
        {

        }

        public UserControl ObterTabela()
        {
            tabelaTaxasServicos.AtualizarRegistros();

            return tabelaTaxasServicos;
        }

        public void DesagruparRegistros()
        {
            tabelaTaxasServicos.AtualizarRegistros();
        }

        public void Pesquisar(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
