using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Shared;
using Serilog;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public class OperacoesGrupoAutomoveis : ICadastravel
    {
        private readonly GrupoAutomoveisAppService grupoAutomoveisService = null;
        private readonly TabelaGrupoAutomoveisControl tabelaGrupoAutomoveis = null;

        public OperacoesGrupoAutomoveis(GrupoAutomoveisAppService GrupoAutomoveisAppService)
        {
            grupoAutomoveisService = GrupoAutomoveisAppService;
            tabelaGrupoAutomoveis = new TabelaGrupoAutomoveisControl(GrupoAutomoveisAppService);
        }

        public void InserirNovoRegistro()
        { 
            TelaCadastroGrupoAutomoveis tela = new TelaCadastroGrupoAutomoveis();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Log.Information("Inserindo novo grupo de automoveis...");

                Stopwatch watch = Stopwatch.StartNew();

                grupoAutomoveisService.InserirNovo(tela.GrupoAutomoveis);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] inserido com sucesso");

                watch.Stop();

                Log.Information("Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] inserido com sucesso ({Ms}ms)", tela.GrupoAutomoveis.Id, watch.ElapsedMilliseconds);
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de automóveis para editar!!", "Edição de Grupo de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomoveis grupoAutomoveisSelecionado = grupoAutomoveisService.SelecionarPorId(id);

            TelaCadastroGrupoAutomoveis tela = new TelaCadastroGrupoAutomoveis();

            tela.GrupoAutomoveis = grupoAutomoveisSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                Log.Information("Editando grupo de automoveis...");

                Stopwatch watch = Stopwatch.StartNew();

                grupoAutomoveisService.Editar(id, tela.GrupoAutomoveis);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] editado com sucesso");

                watch.Stop();

                Log.Information("Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] editado com sucesso ({Ms}ms)", id, watch.ElapsedMilliseconds);
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaGrupoAutomoveis.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de automóveis para excluir!!", "Exclusão de Grupo de Automóveis",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoAutomoveis grupoAutomoveisSelecionado = grupoAutomoveisService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Automóveis: [{grupoAutomoveisSelecionado.NomeGrupo}] ?",
                "Exclusão de Grupo de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Log.Information("Excluindo grupo de automóveis...");

                Stopwatch watch = Stopwatch.StartNew();

                grupoAutomoveisService.Excluir(id);

                tabelaGrupoAutomoveis.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Grupo Automóvel: [{grupoAutomoveisSelecionado.NomeGrupo}] removido com sucesso");

                watch.Stop();

                Log.Information("Grupo Automóvel: [{tela.GrupoAutomoveis.NomeGrupo}] excluído com sucesso ({Ms}ms)", id, watch.ElapsedMilliseconds);
            }
        }

        public void AgruparRegistros()
        {
            TelaAgrupamentoGrupoAutomoveis telaFiltro = new TelaAgrupamentoGrupoAutomoveis();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                tabelaGrupoAutomoveis.AgruparGrupoDeAutomoveis(telaFiltro.TipoAgrupamento);
            }
        }
        public void FiltrarRegistros()
        {
            
        }

        public UserControl ObterTabela()
        {
            tabelaGrupoAutomoveis.AtualizarRegistros();

            return tabelaGrupoAutomoveis;
        }

        public void DesagruparRegistros()
        {
            tabelaGrupoAutomoveis.DesagruparGrupoAutomoveis();
        }

        public void Pesquisar(string text)
        {
            throw new NotImplementedException();
        }
    }
}
