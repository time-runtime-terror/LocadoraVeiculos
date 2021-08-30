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
                txtKmIncluida.Text = grupoAutomoveis.KmControladoIncluida.ToString();
                txtLivreUm.Text = grupoAutomoveis.KmLivreUm.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nomeGrupo = txtNomeGrupo.Text;

            string planoDiarioUmstr = txtDiarioUm.Text;

            string planoDiarioDoisstr = txtDiarioDois.Text;

            string kmControladoUmstr = txtControladoUm.Text;

            string kmControladoDoisstr = txtControladoDois.Text;

            string kmControladaIncluidastr = txtKmIncluida.Text;

            string kmLivreUmstr = txtLivreUm.Text;

            //separar

            double planoDiarioUm = validarGrupos(planoDiarioUmstr);

            double planoDiarioDois = validarGrupos(planoDiarioDoisstr);

            double kmControladoUm = validarGrupos(kmControladoUmstr);

            double kmControladoDois = validarGrupos(kmControladoDoisstr);

            double kmCotroladaIncluida = validarGrupos(kmControladaIncluidastr);

            double kmLivreUm = validarGrupos(kmLivreUmstr);

            GrupoAutomoveis = new GrupoAutomoveis(nomeGrupo, planoDiarioUm, planoDiarioDois, kmControladoUm, kmControladoDois,
               kmLivreUm, kmCotroladaIncluida);

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
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Plano Diário, por favor.");
                txtDiarioUm.Text = txtDiarioUm.Text.Remove(txtDiarioUm.Text.Length - 1);
            }
        }

        private void txtControladoUm_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtControladoUm.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Km Controlado, por favor.");
                txtControladoUm.Text = txtControladoUm.Text.Remove(txtControladoUm.Text.Length - 1);
            }
        }

        private void txtLivreUm_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLivreUm.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Km Livre, por favor.");
                txtLivreUm.Text = txtLivreUm.Text.Remove(txtLivreUm.Text.Length - 1);
            }
        }

        private void txtDiarioDois_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDiarioDois.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Plano Diário por Km Rodado, por favor.");
                txtDiarioDois.Text = txtDiarioDois.Text.Remove(txtDiarioDois.Text.Length - 1);
            }
        }

        private void txtControladoDois_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtControladoDois.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Km Controlado por Km Rodado, por favor.");
                txtControladoDois.Text = txtControladoDois.Text.Remove(txtControladoDois.Text.Length - 1);
            }
        }

        private void TelaCadastroGrupoAutomoveis_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard.Instancia.AtualizarRodape($"Cadastro de Grupo de Automóveis");
        }

        private void txtKmIncluida_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtKmIncluida.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape($"Apenas números no Km Controlado Incluído, por favor.");
                txtKmIncluida.Text = txtKmIncluida.Text.Remove(txtKmIncluida.Text.Length - 1);
            }
        }
    }
}
