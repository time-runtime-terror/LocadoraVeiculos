using LocadoraVeiculos.Controladores.TaxasServicosModule;
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
using LocadoraVeiculos.WindowsApp.Features.CombustivelModule;
using LocadoraVeiculos.Controladores.CombustivelModule;
using LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.DevolucaoModule;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class Dashboard : Form
    {
        private ICadastravel operacoes; 

        public static Dashboard Instancia { get; set; }

        public Dashboard()
        {
            InitializeComponent();

            Instancia = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        #region Eventos de Click dos Botões do Menu Principal

        private void btnLocacoes_Click(object sender, EventArgs e)
        {
            ConfiguracoesLocacaoToolBox config = new ConfiguracoesLocacaoToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            operacoes = new OperacoesLocacao();

            ConfigurarPainelRegistros();
        }

        private void btnCadastrarDevolucoes_Click(object sender, EventArgs e)
        {
            //ConfiguracoesDevolucaoToolBox config = new ConfiguracoesDevolucaoToolBox();

            //ConfigurarToolBox(config);

            //AtualizarRodape(config.TipoCadastro);

            //operacoes = new OperacoesDevolucao();

            //ConfigurarPainelRegistros();
        }

        private void btnCadastroClientes_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoClienteToolBox config = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            operacoes = new OperacoesCliente();

            ConfigurarPainelRegistros();
        }

        private void btnCadastroFuncionario_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(new ControladorFuncionario());

            ConfigurarPainelRegistros();
        }

        private void btnCadastroVeiculoModules_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculos(new ControladorVeiculo());

            ConfigurarPainelRegistros();
        }

        private void btnCadastroGrupoAutomoveis_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoAutomoveisToolBox configuracao = new ConfiguracaoGrupoAutomoveisToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoAutomoveis(new ControladorGrupoAutomoveis());

            ConfigurarPainelRegistros();
        }

        private void btnTaxasServicos_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxasServicosToolBox config = new ConfiguracaoTaxasServicosToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            operacoes = new OperacoesTaxasServicos(new ControladorTaxasServicos());

            ConfigurarPainelRegistros();
        }

        private void btnConfiguracoes_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoCombustivelToolBox configuracao = new ConfiguracaoCombustivelToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            ConfigurarPainelConfiguracoes();
        }
        #endregion

        #region Eventos de Click dos Botões de CRUD
        private void toolStripBtnAdicionar_Click(object sender, System.EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void toolStripBtnEditar_Click(object sender, System.EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void toolStripBtnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void toolStripBtnFiltrar_Click(object sender, System.EventArgs e)
        {
            txtPesquisa.Text = "Digite para Pesquisar";
            operacoes.FiltrarRegistros();
        }
        private void toolStripBtnAgrupar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "Digite para Pesquisar";
            operacoes.AgruparRegistros();
        }

        private void toolStripBtnDesagrupar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "Digite para Pesquisar";
            operacoes.DesagruparRegistros();
        }
        #endregion

        #region Métodos Privados da Classe
        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarPainelConfiguracoes()
        {
            UserControl tela = new CombustivelControl(new ControladorCombustivel());

            tela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tela);
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

            txtPesquisa.Enabled = configuracao.BarraPesquisa;
            toolStripBtnAdicionar.Enabled = configuracao.BotaoAdicionar;
            toolStripBtnEditar.Enabled = configuracao.BotaoEditar;
            toolStripBtnExcluir.Enabled = configuracao.BotaoExcluir;

            toolStripBtnAgrupar.Enabled = configuracao.BotaoAgrupar;
            toolStripBtnDesagrupar.Enabled = configuracao.BotaoDesagrupar;
            toolStripBtnFiltrar.Enabled = configuracao.BotaoFiltrar;
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void txtPesquisa_Enter(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "Digite para Pesquisar")
                txtPesquisa.Text = "";
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "")
                txtPesquisa.Text = "Digite para Pesquisar";
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisa.Text != "Digite para Pesquisar")
                operacoes.Pesquisar(txtPesquisa.Text);
        }

    }
}
