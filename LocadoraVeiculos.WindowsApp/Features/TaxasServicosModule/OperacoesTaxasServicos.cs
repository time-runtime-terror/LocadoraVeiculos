using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Shared;
using log4net;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public class OperacoesTaxasServicos : ICadastravel
    {
        private readonly TaxasServicosAppService taxasServicosAppService = null;
        private readonly TabelaTaxasServicosControl tabelaTaxasServicos = null;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
                try
                {
                    taxasServicosAppService.InserirNovo(tela.TaxasServicos);

                    tabelaTaxasServicos.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] inserido com sucesso");
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);
                    return;
                }
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
            TaxasServicos taxasServicosSelecionado;

            try
            {
                taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);

                return;
            }

            TelaCadastrarTaxasServicos tela = new TelaCadastrarTaxasServicos();

            tela.TaxasServicos = taxasServicosSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    taxasServicosAppService.Editar(id, tela.TaxasServicos);

                    tabelaTaxasServicos.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] editado com sucesso");
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);

                    return;
                }
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
            

            TaxasServicos taxasServicosSelecionado;

            try
            {
                taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);

                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir esse Serviço?: [{taxasServicosSelecionado.Servico}] ?",
                "Exclusão de Taxas e Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    taxasServicosAppService.Excluir(id);

                    tabelaTaxasServicos.AtualizarRegistros();

                    Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{taxasServicosSelecionado.Servico}] removido com sucesso");

                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    Dashboard.Instancia.AtualizarRodape(ex.Message);

                    return;
                }

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
            try
            {
                tabelaTaxasServicos.AtualizarRegistros();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }
            

            return tabelaTaxasServicos;
        }

        public void DesagruparRegistros()
        {
            try
            {
                tabelaTaxasServicos.AtualizarRegistros();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);

                Dashboard.Instancia.AtualizarRodape(ex.Message);
            }

        }

        public void Pesquisar(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
