using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.netCore.Dominio.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Shared;
using log4net;
using Serilog;
using System;
using System.Diagnostics;
using System.Reflection;
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
                Log.Information("Inserindo nova taxa...");
                Stopwatch watch = Stopwatch.StartNew();

                taxasServicosAppService.InserirNovo(tela.TaxasServicos);

               tabelaTaxasServicos.AtualizarRegistros();

               Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] inserido com sucesso");

                watch.Stop();

                Log.Information("Taxa: [{idTaxa}] inserida com sucesso! ({Ms}ms)", tela.TaxasServicos.Id, watch.ElapsedMilliseconds);

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
                Log.Information("Editando taxa...");
                Stopwatch watch = Stopwatch.StartNew();

                taxasServicosAppService.Editar(id, tela.TaxasServicos);

                tabelaTaxasServicos.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{tela.TaxasServicos.Servico}] editado com sucesso");

                watch.Stop();

                Log.Information("Taxa: [{idTaxa}] editada com sucesso! ({Ms}ms)", tela.TaxasServicos.Id, watch.ElapsedMilliseconds);

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
                Log.Information("Excluindo taxa...");
                Stopwatch watch = Stopwatch.StartNew();
                taxasServicosAppService.Excluir(id);

                tabelaTaxasServicos.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Taxa/Serviço: [{taxasServicosSelecionado.Servico}] removido com sucesso");


                watch.Stop();

                Log.Information("Taxa: [{idTaxa}] excluida com sucesso! ({Ms}ms)", id, watch.ElapsedMilliseconds);

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
