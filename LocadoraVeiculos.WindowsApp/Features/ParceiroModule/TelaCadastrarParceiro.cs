using LocadoraVeiculos.netCore.Dominio.ParceiroModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ParceiroModule
{
    public partial class TelaCadastrarParceiro : Form
    {
        private Parceiro parceiro;
        public TelaCadastrarParceiro()
        {
            InitializeComponent();
        }

        public Parceiro Parceiro
        {
            get { return parceiro; }

            set
            {
                parceiro = value;

                txtId.Text = parceiro.Id.ToString();
                txtNome.Text = parceiro.Nome;
                
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            
            parceiro = new Parceiro(nome);

            string resultadoValidacao = parceiro.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastrarParceiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard.Instancia.AtualizarRodape("Cadastro de Parceiros");
        }
    }
}
