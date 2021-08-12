using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class Dashboard : Form
    {
        private ICadastravel operacoes;

        public static Dashboard Instancia;

        public Dashboard()
        {
            InitializeComponent();

            Instancia = this;
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarToolBox(IConfiguracaoToolBox configuracao)
        {
            toolBoxAcoes.Enabled = true;

            toolStripBtnAdicionar.ToolTipText = configuracao.ToolTipAdicionar;
            toolStripBtnEditar.ToolTipText = configuracao.ToolTipEditar;
            toolStripBtnExcluir.ToolTipText = configuracao.ToolTipExcluir;

            toolStripBtnAgrupar.ToolTipText = configuracao.ToolTipAgrupar;
            toolStripBtnDesagrupar.ToolTipText = configuracao.ToolTipDesagrupar;
            toolStripBtnFiltrar.ToolTipText = configuracao.ToolTipFiltrar;

            toolStripBtnAdicionar.Enabled = configuracao.BotaoAdicionar;
            toolStripBtnEditar.Enabled = configuracao.BotaoEditar;
            toolStripBtnExcluir.Enabled = configuracao.BotaoExcluir;

            toolStripBtnAgrupar.Enabled = configuracao.BotaoAgrupar;
            toolStripBtnDesagrupar.Enabled = configuracao.BotaoDesagrupar;
            toolStripBtnFiltrar.Enabled = configuracao.BotaoFiltrar;
        }

        private void btnCadastroGrupoAutomoveis_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoAutomoveisToolBox configuracao = new ConfiguracaoGrupoAutomoveisToolBox();

            ConfigurarToolBox(configuracao);

            //AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoAutomoveis(new ControladorGrupoAutomoveis());

            ConfigurarPainelRegistros();
        }
            
        private void toolStripBtnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void toolStripBtnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void toolStripBtnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void toolStripBtnAgrupar_Click(object sender, EventArgs e)
        {
            operacoes.AgruparRegistros();
        }

        private void toolStripBtnDesagrupar_Click(object sender, EventArgs e)
        {
            operacoes.DesagruparRegistros();
        }
    }
}
