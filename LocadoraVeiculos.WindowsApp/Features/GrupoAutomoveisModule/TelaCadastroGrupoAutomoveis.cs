using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;
using System;
using System.Collections.Generic;
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

            double planoDiarioUm = Convert.ToDouble(txtDiarioUm.Text);

            double planoDiarioDois = Convert.ToDouble(txtDiarioDois.Text);

            double kmControladoUm = Convert.ToDouble(txtControladoUm.Text);

            double kmControladoDois = Convert.ToDouble(txtControladoDois.Text);

            double kmLivreUm = Convert.ToDouble(txtLivreUm.Text);

            double kmLivreDois = Convert.ToDouble(txtLivreDois.Text);

            GrupoAutomoveis = new GrupoAutomoveis(nomeGrupo, planoDiarioUm, planoDiarioDois, kmControladoUm, kmControladoDois,
                kmLivreUm, kmLivreDois);

            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                //Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
