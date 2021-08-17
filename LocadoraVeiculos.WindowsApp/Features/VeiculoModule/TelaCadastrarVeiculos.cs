using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.Controladores.GrupoAutomoveisModule;
using LocadoraVeiculos.Dominio.GrupoAutomoveisModule;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    public partial class TelaCadastrarVeiculos : Form
    {
        private Veiculo veiculo;
        private byte[] imagemSelecionada;

        private readonly ControladorGrupoAutomoveis controladorGrupoAutomoveis;

        public TelaCadastrarVeiculos()
        {
            InitializeComponent();
            controladorGrupoAutomoveis = new ControladorGrupoAutomoveis();
            PopularGruposDeAutomoveis();
        }

        private void PopularGruposDeAutomoveis()
        {
            foreach (var grupoAutomoveis in controladorGrupoAutomoveis.SelecionarTodos())
                if (!cbTipoVeiculo.Items.Contains(grupoAutomoveis.NomeGrupo))
                    cbTipoVeiculo.Items.Add(grupoAutomoveis.NomeGrupo);
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                txtId.Text = veiculo.Id.ToString();

                imagemSelecionada = veiculo.Foto;

                imgCarro.Image = veiculo.Imagem;

                txtPlaca.Text = veiculo.Placa;
                txtModelo.Text = veiculo.Modelo;
                txtMarca.Text = veiculo.Marca;
                txtTipoCombustivel.Text = veiculo.TipoCombustivel;
                txtCapacidadeTanque.Text = veiculo.CapacidadeTanque;
                txtQuilometragem.Text = veiculo.Quilometragem;

                cbTipoVeiculo.SelectedItem = (veiculo.GrupoAutomoveis != null
                    && cbTipoVeiculo.Items.Contains(veiculo.GrupoAutomoveis.NomeGrupo)) ? veiculo.GrupoAutomoveis.NomeGrupo : null;
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                imagemSelecionada = File.ReadAllBytes(fdlg.FileName);

                using (var ms = new MemoryStream(imagemSelecionada))
                    imgCarro.Image = new Bitmap(ms);
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            string placa = txtPlaca.Text;
            string modelo = txtModelo.Text;
            string marca = txtMarca.Text;
            string tipoCombustivel = txtTipoCombustivel.Text;
            string capacidadeTanque = txtCapacidadeTanque.Text;
            string quilometragem = txtQuilometragem.Text;

            var listaGrupos = controladorGrupoAutomoveis.SelecionarTodos();

            GrupoAutomoveis grupo = listaGrupos.Find(x => x.NomeGrupo == (string)cbTipoVeiculo.SelectedItem); ;

            veiculo = new Veiculo(imagemSelecionada, placa, modelo, marca,
                tipoCombustivel, capacidadeTanque, quilometragem, grupo);

            string resultadoValidacao = veiculo.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                MessageBox.Show(resultadoValidacao, "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
