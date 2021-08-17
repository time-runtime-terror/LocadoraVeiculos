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
using LocadoraVeiculos.Controladores.CombustivelModule;
using LocadoraVeiculos.Dominio.CombustivelModule;

namespace LocadoraVeiculos.WindowsApp.Features.CombustivelModule
{
    public partial class CombustivelControl : UserControl
    {
        private Combustivel combustivel;
        private readonly ControladorCombustivel controlador = null;
        public CombustivelControl(ControladorCombustivel ctrlCombustivel)
        {
            InitializeComponent();
            controlador = ctrlCombustivel;

            txbGasolina.Text = controlador.PegarValorGasolina();
            txbEtanol.Text = controlador.PegarValorEtanol();
            txbDiesel.Text = controlador.PegarValorDiesel();
            txbGnv.Text = controlador.PegarValorGnv();

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string gasolinaStr = txbGasolina.Text;
            string etanolStr = txbEtanol.Text;
            string dieselStr = txbDiesel.Text;
            string gnvStr = txbGnv.Text;

            double gasolina, etanol, diesel, gnv;
            if(string.IsNullOrEmpty(gasolinaStr) || string.IsNullOrEmpty(etanolStr) || string.IsNullOrEmpty(dieselStr) || string.IsNullOrEmpty(gnvStr))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
            else
            {
                gasolina = Convert.ToDouble(gasolinaStr);
                etanol = Convert.ToDouble(etanolStr);
                diesel = Convert.ToDouble(dieselStr);
                gnv = Convert.ToDouble(gnvStr);

                combustivel = new Combustivel(gasolina, etanol, diesel, gnv);

                string resultadoValidacao = combustivel.Validar();

                if (resultadoValidacao != "ESTA_VALIDO")
                {
                    
                    MessageBox.Show(resultadoValidacao);


                    //DialogResult = DialogResult.None;
                }
                else
                {
                    controlador.GravarCombustivel(combustivel);
                    MessageBox.Show("Combustiveis gravados com sucesso");
                }
            } 
        }
    }
}
