using LocadoraVeiculos.WindowsApp.Features.ClienteModule;
using LocadoraVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule;
using System;
using System.Windows.Forms;
using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Feature.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using LocadoraVeiculos.Controladores.FuncionarioModule;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class Dashboard : Form
    {
        private ICadastravel operacoes; 

        public static Dashboard Instancia;
        private OperacoesVeiculos operacaoVeiculos;

        public Dashboard()
        {
            InitializeComponent();

            Instancia = this;
        }

        private void btnCadastroClientes_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoClienteToolBox config = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(config);

            operacoes = new OperacoesCliente();

            ConfigurarPainelRegistros();
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void btnCadastroFuncionario_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(new ControladorFuncionario());

            ConfigurarPainelRegistros();
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

        private void toolStripBtnAdicionar_Click(object sender, System.EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void toolStripBtnEditar_Click(object sender, System.EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void btnCadastroGrupoAutomoveis_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoAutomoveisToolBox configuracao = new ConfiguracaoGrupoAutomoveisToolBox();

            ConfigurarToolBox(configuracao);

            //AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoAutomoveis(new ControladorGrupoAutomoveis());

            ConfigurarPainelRegistros();
        }

        private void toolStripBtnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void toolStripBtnFiltrar_Click(object sender, System.EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }
        private void toolStripBtnAgrupar_Click(object sender, EventArgs e)
        {
            operacoes.AgruparRegistros();
        }

        private void toolStripBtnDesagrupar_Click(object sender, EventArgs e)
        {
            operacoes.DesagruparRegistros();
        }
        private void btnCadastroVeiculoModules_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            //AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculos(new ControladorVeiculo());

            ConfigurarPainelRegistros();
            
        }


    }
}
