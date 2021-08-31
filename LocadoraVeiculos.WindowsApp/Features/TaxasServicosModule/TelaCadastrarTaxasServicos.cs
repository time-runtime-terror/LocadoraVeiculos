using System;
using LocadoraVeiculos.Dominio.TaxasServicosModule;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace LocadoraVeiculos.WindowsApp.Features.TaxasServicosModule
{
    public partial class TelaCadastrarTaxasServicos : Form
    {
        private TaxasServicos taxasServicos;

        public TelaCadastrarTaxasServicos()
        {
            InitializeComponent();
        }

        public TaxasServicos TaxasServicos
        {
            get { return taxasServicos; }

            set
            {
                taxasServicos = value;

                txtId.Text = taxasServicos.Id.ToString();
                txtServico.Text = taxasServicos.Servico;
                txtTaxa.Text = taxasServicos.Taxa.ToString();
                cmbTipo.Text = taxasServicos.OpcaoServico.ToString();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string servico = txtServico.Text;
            string taxastr = txtTaxa.Text;
            string opcaoServico = cmbTipo.Text;

            string localServico = null;

            if (rdbLocacao.Checked)
            {
                localServico = "Locação";
            }
            else if (rdbDevolucao.Checked)
            {
                localServico = "Devolução";
            }

            double taxa = validarGrupos(taxastr);

            taxasServicos = new TaxasServicos(servico, taxa, opcaoServico, localServico);

            string resultadoValidacao = taxasServicos.Validar();

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

        private void txtTaxa_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTaxa.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Taxa: Por favor digite apenas números!");
                txtTaxa.Text = txtTaxa.Text.Remove(txtTaxa.Text.Length - 1);
            }
        }
    }
}
