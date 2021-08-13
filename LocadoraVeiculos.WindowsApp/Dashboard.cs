using LocadoraVeiculos.WindowsApp.Features.FuncionarioModule;
using LocadoraVeiculos.WindowsApp.Shared;
using System.Windows.Forms;
using LocadoraVeiculos.Controladores.FuncionarioModule;

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

        private void toolStripBtnExcluir_Click(object sender, System.EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }


    }
}
