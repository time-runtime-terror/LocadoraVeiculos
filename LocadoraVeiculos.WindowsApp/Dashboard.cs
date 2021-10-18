using LocadoraVeiculos.WindowsApp.Features.ClienteModule;
using LocadoraVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule;
using System;
using System.Windows.Forms;
using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.WindowsApp.Feature.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.CombustivelModule;
using LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule;
using LocadoraVeiculos.WindowsApp.Features.LocacaoModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;
using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.VeiculosModule;
using LocadoraVeiculos.Aplicacao.VeiculosModule;
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
using LocadoraVeiculos.Infra.JSON.CombustivelModule;
using Serilog;
using LocadoraVeiculos.netCore.Dominio.LocacaoModule;
using LocadoraVeiculos.Infra.ORM.Modules.FuncionarioModule;
using LocadoraVeiculos.Infra.ORM;
using LocadoraVeiculos.Infra.ORM.Modules.LocacaoModule;
using LocadoraVeiculos.Infra.ORM.Modules.TaxasServicosModule;
using LocadoraVeiculos.Infra.ORM.Modules.VeiculoModule;
using LocadoraVeiculos.Infra.ORM.Modules.ClienteModule;
using LocadoraVeiculos.Infra.ORM.Modules.GrupoAutomoveisModule;

namespace LocadoraVeiculos.WindowsApp
{
    public partial class Dashboard : Form
    {
        private ICadastravel operacoes;
        private INotificadorEmail notificadorEmail;
        private IVerificadorConexao verificadorConexao;
        private LocadoraDbContext dbContext;

        public static Dashboard Instancia { get; set; }
        public string Usuario { get; set; }

        public Dashboard(string usuario)
        {
            InitializeComponent();

            Instancia = this;
            Usuario = usuario;
            Log.Debug($"Usuário [{ Usuario }]: Login completo... Executando o Dashboard.");

            notificadorEmail = new NotificadorEmail();
            verificadorConexao = new VerificadorConexao();

            if (verificadorConexao.TemConexaoComInternet())
            {
                EnviarEmailsAgendados();
                Instancia.AtualizarRodape("Conexão estabelecida! Emails agendados enviados com sucesso.");
            }
            else
                Instancia.AtualizarRodape("Sem conexão com a internet! Não foi possível enviar emails agendados.");
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
            dbContext = new LocadoraDbContext();

            ConfiguracoesLocacaoToolBox config = new ConfiguracoesLocacaoToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            //LocacaoDAO locacaoRepo 
            //    = new LocacaoDAO(new ClienteDAO(), new VeiculosDAO(new GrupoAutomoveisDAO()), new TaxasServicosDAO());

            LocacaoRepositoryEF locacaoRepoOrm = new LocacaoRepositoryEF(dbContext);

            LocacaoAppService locacaoService = new LocacaoAppService(locacaoRepoOrm, new GeradorRecibo(), new NotificadorEmail(), new VerificadorConexao());

            TaxasServicosRepositoryEF taxaRepoOrm = new TaxasServicosRepositoryEF(dbContext);

            TaxasServicosAppService taxaService = new TaxasServicosAppService(taxaRepoOrm);

            VeiculoRepositoryEF veiculoRepoOrm = new VeiculoRepositoryEF(dbContext);

            VeiculoAppService veiculoService = new VeiculoAppService(veiculoRepoOrm);

            ClienteRepositoryEF clienteRepoOrm = new ClienteRepositoryEF(dbContext);

            ClienteAppService clienteService = new ClienteAppService(clienteRepoOrm);

            operacoes = new OperacoesLocacao(locacaoService, taxaService, veiculoService, clienteService);

            ConfigurarPainelRegistros();
        }

        private void btnCadastroClientes_Click(object sender, System.EventArgs e)
        {
            dbContext = new LocadoraDbContext();

            ConfiguracaoClienteToolBox config = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            ClienteRepositoryEF clienteRepoOrm = new ClienteRepositoryEF(dbContext);

            ClienteAppService clienteService = new ClienteAppService(clienteRepoOrm);

            operacoes = new OperacoesCliente(clienteService);

            ConfigurarPainelRegistros();
        }

        private void btnCadastroFuncionario_Click(object sender, System.EventArgs e)
        {
            dbContext = new LocadoraDbContext();

            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            FuncionarioRepositoryEF funcionarioRepo = new FuncionarioRepositoryEF(dbContext);

            operacoes = new OperacoesFuncionario(new FuncionarioAppService(funcionarioRepo));

            ConfigurarPainelRegistros();
        }

        private void btnCadastroVeiculoModules_Click(object sender, System.EventArgs e)
        {
            dbContext = new LocadoraDbContext();

            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            VeiculoRepositoryEF veiculoRepoOrm = new VeiculoRepositoryEF(dbContext);

            VeiculoAppService veiculosService = new VeiculoAppService(veiculoRepoOrm);

            GrupoAutomoveisRepositoryEF grupoAutoRepoOrm = new GrupoAutomoveisRepositoryEF(dbContext);

            GrupoAutomoveisAppService grupoAutomoveisService = new GrupoAutomoveisAppService(grupoAutoRepoOrm);

            operacoes = new OperacoesVeiculos(veiculosService, grupoAutomoveisService);

            ConfigurarPainelRegistros();
        }

        private void btnCadastroGrupoAutomoveis_Click(object sender, EventArgs e)
        {
            dbContext = new LocadoraDbContext();

            ConfiguracaoGrupoAutomoveisToolBox configuracao = new ConfiguracaoGrupoAutomoveisToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            GrupoAutomoveisRepositoryEF grupoAutoRepoOrm = new GrupoAutomoveisRepositoryEF(dbContext);

            GrupoAutomoveisAppService grupoAutomoveisService = new GrupoAutomoveisAppService(grupoAutoRepoOrm);

            operacoes = new OperacoesGrupoAutomoveis(grupoAutomoveisService);

            ConfigurarPainelRegistros();
        }

        private void btnTaxasServicos_Click(object sender, EventArgs e)
        {
            dbContext = new LocadoraDbContext();

            ConfiguracaoTaxasServicosToolBox config = new ConfiguracaoTaxasServicosToolBox();

            ConfigurarToolBox(config);

            AtualizarRodape(config.TipoCadastro);

            TaxasServicosDAO taxasRepo = new TaxasServicosDAO();

            TaxasServicosRepositoryEF taxasRepoOrm = new TaxasServicosRepositoryEF(dbContext);

            operacoes = new OperacoesTaxasServicos(new TaxasServicosAppService(taxasRepoOrm));

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

        private void EnviarEmailsAgendados()
        {
            try
            {
                notificadorEmail.EnviarEmailsAgendadosAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Falha ao tentar enviar emails agendados.");
            }
        }

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
            UserControl tela = new CombustivelControl(new CombustivelConfiguration());

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
            Log.Debug($"Usuário [{ Usuario }]: Encerrando a execução...");
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
