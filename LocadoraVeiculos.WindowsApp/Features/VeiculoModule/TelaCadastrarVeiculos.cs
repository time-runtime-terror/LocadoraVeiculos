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
using LocadoraVeiculoModules.WindowsApp;
using LocadoraVeiculos.Dominio.VeiculoModule;
//using LocadoraVeiculos.Dominio.GrupoVeiculosModule;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    public partial class TelaCadastrarVeiculos : Form
    {
        private Veiculo veiculo;
       // private readonly List<tipoVeiculo> tipoVeiculos;

        public TelaCadastrarVeiculos()
        {
            InitializeComponent();
            //this.tipoVeiculos = tipoVeiculos;
            Pupulacb();
        }

        private void Pupulacb()
        {
            //foreach (var tipoVeiculo in tipoVeiculos)
            //{
            //    cbTipoVeiculo.Items.Add(tipoVeiculo);
            //}
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                txtId.Text = veiculo.Id.ToString();
                txtModelo.Text = veiculo.Modelo;
                txtMarca.Text = veiculo.Marca;
                txtTipoCombustivel.Text = veiculo.TipoCombustivel;
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque;
                txtQuilometragem.Text = veiculo.Quilometragem;
                cbTipoVeiculo.Text = veiculo.TipoVeiculo;
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                byte[] imgData = File.ReadAllBytes(fdlg.FileName);
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            //operacoes.InserirNovoRegistro();
            string placa = txtPlaca.Text;
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            string tipoCombustivel = txtTipoCombustivel.Text;
            string capacidadeTanque = txtCapacidadeTanque.Text;
            string quilometragem = txtQuilometragem.Text;
            string tipoVeiculo = cbTipoVeiculo.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
