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
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                Dashboard.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dashboard.Instancia.AtualizarRodape("Cadastro de Veiculos");
        }

        private void txtCapacidadeTanque_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCapacidadeTanque.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Por favor, apenas números.");
                txtCapacidadeTanque.Text = txtCapacidadeTanque.Text.Remove(txtCapacidadeTanque.Text.Length - 1);
            }
        }

        private void txtQuilometragem_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuilometragem.Text, "[^0-9]"))
            {
                Dashboard.Instancia.AtualizarRodape("Por favor, apenas números.");
                txtQuilometragem.Text = txtQuilometragem.Text.Remove(txtQuilometragem.Text.Length - 1);
            }
        }
    }
}
