using LocadoraVeiculos.netCore.Controladores.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.ClienteModule;
using LocadoraVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraVeiculos.netCore.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule;
using System;
using System.Windows.Forms;
using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.WindowsApp.Feature.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using LocadoraVeiculos.netCore.Controladores.FuncionarioModule;
using LocadoraVeiculos.WindowsApp.Features.CombustivelModule;
using LocadoraVeiculos.netCore.Controladores.CombustivelModule;
using LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using LocadoraVeiculos.WindowsApp.Features.DevolucaoModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
using LocadoraVeiculos.netCore.Dominio.ClienteModule;
using LocadoraVeiculos.Aplicacao.ClienteModule;
using LocadoraVeiculos.Infra.SQL.ClienteModule;
using LocadoraVeiculos.Aplicacao.FuncionarioModule;
using LocadoraVeiculos.Infra.SQL.FuncionarioModule;
using LocadoraVeiculos.Infra.SQL.TaxasServicosModule;
using LocadoraVeiculos.Aplicacao.TaxasServicosModule;
using LocadoraVeiculos.Infra.SQL.LocacaoModule;
using LocadoraVeiculos.Aplicacao.LocacaoModule;
using LocadoraVeiculos.Infra.PDF.LocacaoModule;
using LocadoraVeiculos.Infra.InternetServices.LocacaoModule;

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

        public void DesabilitarBotoesIndisponiveisParaDevolucao()
        {
            toolStripBtnDevolucao.Enabled = false;
            toolStripBtnEditar.Enabled = false;
            toolStripBtnExcluir.Enabled = true;
        }

        public void HabilitarBotoesIndisponiveisParaDevolucao()
        {
            toolStripBtnDevolucao.Enabled = true;
            toolStripBtnEditar.Enabled = true;
            toolStripBtnExcluir.Enabled = false;
        }


        #region Eventos de Click dos Botões do Menu Principal

        private void btnLocacoes_Click(object sender, EventArgs e)
        {
            ConfiguracoesLocacaoToolBox config = new ConfiguracoesLocacaoToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            LocacaoDAO locacaoRepo 
                = new LocacaoDAO(new ClienteDAO(), new VeiculosDAO(new GrupoAutomoveisDAO()), new TaxasServicosDAO());

            LocacaoAppService locacaoService = new LocacaoAppService(locacaoRepo, new GeradorRecibo(), new NotificadorEmail(), new VerificadorConexao());

            TaxasServicosAppService taxaService = new TaxasServicosAppService(new TaxasServicosDAO());

            VeiculoAppService veiculoService = new VeiculoAppService(new VeiculosDAO(new GrupoAutomoveisDAO()));

            ClienteAppService clienteService = new ClienteAppService(new ClienteDAO());

            operacoes = new OperacoesLocacao(locacaoService, taxaService, veiculoService, clienteService);

            ConfigurarPainelRegistros();

            operacoes.DesagruparRegistros();
        }

        private void btnCadastroClientes_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoClienteToolBox config = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            ClienteDAO clienteRepo = new ClienteDAO();

            ClienteAppService clienteService = new ClienteAppService(clienteRepo);

            operacoes = new OperacoesCliente(clienteService);

            ConfigurarPainelRegistros();
        }

        private void btnCadastroFuncionario_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            FuncionarioDAO funcionarioRepo = new FuncionarioDAO();

            operacoes = new OperacoesFuncionario(new FuncionarioAppService(funcionarioRepo));

            ConfigurarPainelRegistros();
        }

        private void btnCadastroVeiculoModules_Click(object sender, System.EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            GrupoAutomoveisDAO grupoAutomoveisRepo = new GrupoAutomoveisDAO();

            VeiculosDAO veiculosRepo = new VeiculosDAO(grupoAutomoveisRepo);

            VeiculoAppService veiculosService = new VeiculoAppService(veiculosRepo);

            operacoes = new OperacoesVeiculos(veiculosService);

            ConfigurarPainelRegistros();
        }

        private void btnCadastroGrupoAutomoveis_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoAutomoveisToolBox configuracao = new ConfiguracaoGrupoAutomoveisToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            GrupoAutomoveisDAO grupoAutomoveisRepo = new GrupoAutomoveisDAO();

            GrupoAutomoveisAppService grupoAutomoveisService = new GrupoAutomoveisAppService(grupoAutomoveisRepo);

            operacoes = new OperacoesGrupoAutomoveis(grupoAutomoveisService);

            ConfigurarPainelRegistros();
        }

        private void btnTaxasServicos_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxasServicosToolBox config = new ConfiguracaoTaxasServicosToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            TaxasServicosDAO taxasRepo = new TaxasServicosDAO();

            operacoes = new OperacoesTaxasServicos(new TaxasServicosAppService(taxasRepo));

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

        private void toolStripBtnDevolucao_Click(object sender, EventArgs e)
        {
            if (operacoes is OperacoesLocacao)
                ((OperacoesLocacao)operacoes).RegistrarDevolucao();
        }
        #endregion

        #region Métodos Privados da Classe
        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);

            operacoes.DesagruparRegistros();
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
            toolStripBtnDevolucao.ToolTipText = configuracao.ToolTipDevolucao;

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

            toolStripBtnDevolucao.Visible = configuracao.BotaoDevolucao;
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
