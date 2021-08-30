using LocadoraVeiculos.Controladores.TaxasServicosModule;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public class OperacoesTaxasServicos : ICadastravel
    {
        private readonly ControladorTaxasServicos controlador = null;
        private readonly TabelaTaxasServicosControl tabelaTaxasServicos = null;

        public OperacoesTaxasServicos(ControladorTaxasServicos controladorTaxasServicos)
        {
            controlador = controladorTaxasServicos;
            tabelaTaxasServicos = new TabelaTaxasServicosControl(controladorTaxasServicos);
        }

        public void InserirNovoRegistro()
        {

            TelaCadastrarTaxasServicos tela = new TelaCadastrarTaxasServicos();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.TaxasServicos);

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

            TaxasServicos taxasServicosSelecionado = controlador.SelecionarPorId(id);

            TelaCadastrarTaxasServicos tela = new TelaCadastrarTaxasServicos();

            tela.TaxasServicos = taxasServicosSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.TaxasServicos);

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

            TaxasServicos taxasServicosSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir esse Serviço?: [{taxasServicosSelecionado.Servico}] ?",
                "Exclusão de Taxas e Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

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
