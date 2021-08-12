using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.GrupoAutomoveisModule
{
    public partial class TelaCadastroGrupoAutomoveis : Form
    {
        private GrupoAutomoveis grupoAutomoveis;

        public TelaCadastroGrupoAutomoveis()
        {
            InitializeComponent();
        }

        public GrupoAutomoveis GrupoAutomoveis
        {
            get { return grupoAutomoveis; }

            set
            {
                grupoAutomoveis = value;

                txtId.Text = grupoAutomoveis.Id.ToString();
                txtNomeGrupo.Text = grupoAutomoveis.NomeGrupo;
                txtDiarioUm.Text = grupoAutomoveis.PlanoDiarioUm.ToString();
                txtDiarioDois.Text = grupoAutomoveis.PlanoDiarioDois.ToString();
                txtControladoUm.Text = grupoAutomoveis.KmControladoUm.ToString();
                txtControladoDois.Text = grupoAutomoveis.KmControladoDois.ToString();
                txtLivreUm.Text = grupoAutomoveis.KmLivreUm.ToString();
                txtLivreDois.Text = grupoAutomoveis.KmLivreDois.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nomeGrupo = txtNomeGrupo.Text;

            string planoDiarioUm = txtDiarioUm.Text;

            string planoDiarioDois = txtDiarioDois.Text;

            string kmControladoUm = txtControladoUm.Text;

            string kmControladoDois = txtControladoDois.Text;

            string kmLivreUm = txtLivreUm.Text;

            string kmLivreDois = txtLivreDois.Text;

            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                //instancia

                DialogResult = DialogResult.None;
            }
        }
    }
}
