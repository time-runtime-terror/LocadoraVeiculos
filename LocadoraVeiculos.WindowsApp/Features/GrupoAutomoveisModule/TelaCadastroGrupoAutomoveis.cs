using LocadoraVeiculos.WindowsApp;
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

            string planoDiarioUmstr = txtDiarioUm.Text;

            string planoDiarioDoisstr = txtDiarioDois.Text;

            string kmControladoUmstr = txtControladoUm.Text;

            string kmControladoDoisstr = txtControladoDois.Text;

            string kmLivreUmstr = txtLivreUm.Text;

            string kmLivreDoisstr = txtLivreDois.Text;

            //separar

            double planoDiarioUm = validarGrupos(planoDiarioUmstr);

            double planoDiarioDois = validarGrupos(planoDiarioDoisstr);

            double kmControladoUm = validarGrupos(kmControladoUmstr);

            double kmControladoDois = validarGrupos(kmControladoDoisstr);

            double kmLivreUm = validarGrupos(kmLivreUmstr);

            double kmLivreDois = validarGrupos(kmLivreDoisstr);

            GrupoAutomoveis = new GrupoAutomoveis(nomeGrupo, planoDiarioUm, planoDiarioDois, kmControladoUm, kmControladoDois,
                kmLivreUm, kmLivreDois);

            string resultadoValidacao = grupoAutomoveis.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private static double validarGrupos(string planoStr)
        {
            double plano;
            if (string.IsNullOrEmpty(planoStr))
            {
                plano = 0;
            }
            else
            {
                plano = Convert.ToDouble(planoStr);
            }

            return plano;
        }

        private void txtDiarioUm_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDiarioUm.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtDiarioUm.Text = txtDiarioUm.Text.Remove(txtDiarioUm.Text.Length - 1);
            }
        }

        private void txtControladoUm_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtControladoUm.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtControladoUm.Text = txtControladoUm.Text.Remove(txtControladoUm.Text.Length - 1);
            }
        }

        private void txtLivreUm_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLivreUm.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtLivreUm.Text = txtLivreUm.Text.Remove(txtLivreUm.Text.Length - 1);
            }
        }

        private void txtDiarioDois_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDiarioDois.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtDiarioDois.Text = txtDiarioDois.Text.Remove(txtDiarioDois.Text.Length - 1);
            }
        }

        private void txtControladoDois_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtControladoDois.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtControladoDois.Text = txtControladoDois.Text.Remove(txtControladoDois.Text.Length - 1);
            }
        }

        private void txtLivreDois_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLivreDois.Text, "[^0-9]"))
            {
                MessageBox.Show("Por favor, apenas números.");
                txtLivreDois.Text = txtLivreDois.Text.Remove(txtLivreDois.Text.Length - 1);
            }
        }
    }
}
