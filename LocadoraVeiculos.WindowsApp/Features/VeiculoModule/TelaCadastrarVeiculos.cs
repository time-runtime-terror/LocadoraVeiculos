using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LocadoraVeiculos.netCore.Dominio.VeiculoModule;
using LocadoraVeiculos.netCore.Dominio.GrupoAutomoveisModule;
using LocadoraVeiculos.Aplicacao.GrupoAutomoveisModule;
using LocadoraVeiculos.Infra.SQL.GrupoAutomoveisModule;

namespace LocadoraVeiculos.WindowsApp.Features.VeiculoModule
{
    public partial class TelaCadastrarVeiculos : Form
    {
        private List<string> tiposCombustivel = new List<string>() {"Gasolina", "Etanol", "Diesel", "Gnv"};
        private Veiculo veiculo;
        private byte[] imagemSelecionada;

        private readonly GrupoAutomoveisAppService grupoAutomoveisService;

        public TelaCadastrarVeiculos(GrupoAutomoveisAppService grupoAutoService)
        {
            InitializeComponent();
            grupoAutomoveisService = grupoAutoService;
            PopularGruposDeAutomoveis();
            PopularTiposCombustivel();
         
        }

        private void PopularGruposDeAutomoveis()
        {
            foreach (var grupoAutomoveis in grupoAutomoveisService.SelecionarTodos())
                if (!cbTipoVeiculo.Items.Contains(grupoAutomoveis.NomeGrupo))
                    cbTipoVeiculo.Items.Add(grupoAutomoveis.NomeGrupo);
        }

        private void PopularTiposCombustivel()
        {
            foreach (var combustivel in tiposCombustivel)
                    cmbTipoCombustivel.Items.Add(combustivel);
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
                
                txtCapacidadeTanque.Text = Convert.ToString(veiculo.CapacidadeTanque);
                txtQuilometragem.Text = Convert.ToString(veiculo.Quilometragem);

                SelecionarGrupoAutomoveis();

                SelecionarTipoCombustivel();
            }
        }

        private void SelecionarGrupoAutomoveis()
        {
            cbTipoVeiculo.SelectedItem = (veiculo.GrupoAutomoveis != null
                    && cbTipoVeiculo.Items.Contains(veiculo.GrupoAutomoveis.NomeGrupo)) ? veiculo.GrupoAutomoveis.NomeGrupo : null;
        }

        private void SelecionarTipoCombustivel()
        {
            cmbTipoCombustivel.SelectedItem = Veiculo.TipoCombustivel;
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
            
            string capacidadeTanqueStr = txtCapacidadeTanque.Text;
            string quilometragemStr = txtQuilometragem.Text;

            int capacidadeTanque = validarCamposInt(capacidadeTanqueStr);
            int quilometragem = validarCamposInt(quilometragemStr);

            string tipoCombustivel = null;

            if(cmbTipoCombustivel.SelectedIndex == 0)
            {
                 tipoCombustivel = Convert.ToString(cmbTipoCombustivel.SelectedItem);
            }
            else if(cmbTipoCombustivel.SelectedIndex == 1)
            {
                tipoCombustivel = Convert.ToString(cmbTipoCombustivel.SelectedItem);
            }
            else if (cmbTipoCombustivel.SelectedIndex == 2)
            {
                tipoCombustivel = Convert.ToString(cmbTipoCombustivel.SelectedItem);
            }
            else if (cmbTipoCombustivel.SelectedIndex == 3)
            {
                tipoCombustivel = Convert.ToString(cmbTipoCombustivel.SelectedItem);
            }


            var listaGrupos = grupoAutomoveisService.SelecionarTodos();

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

        private static int validarCamposInt(string campoStr)
        {
            int campo;
            if (string.IsNullOrEmpty(campoStr))
            {
                campo = 0;
            }
            else
            {
                campo = Convert.ToInt32(campoStr);
            }

            return campo;
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

        private void TelaCadastrarVeiculos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard.Instancia.AtualizarRodape("Cadastro de Veiculos");
        }
    }
}
