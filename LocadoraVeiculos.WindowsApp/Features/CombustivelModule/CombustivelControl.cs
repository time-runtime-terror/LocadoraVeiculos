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
using LocadoraVeiculos.netCore.Controladores.CombustivelModule;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;

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

            //colocando os zeros, se for necessário
            txbGasolina.Text = PadronizarTextBox(txbGasolina.Text);
            txbEtanol.Text = PadronizarTextBox(txbEtanol.Text);
            txbDiesel.Text = PadronizarTextBox(txbDiesel.Text);
            txbGnv.Text = PadronizarTextBox(txbGnv.Text);
        }

        private string PadronizarTextBox(string text)
        {

            if (text.Length == 2)
            {
                text += "00";
            }

            if(text.Length == 3)
            {
                text += "0";
            }

            return text;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string gasolinaStr = txbGasolina.Text;
            string etanolStr = txbEtanol.Text;
            string dieselStr = txbDiesel.Text;
            string gnvStr = txbGnv.Text;

            double gasolina, etanol, diesel, gnv;

            if(!txbGasolina.MaskCompleted || !txbEtanol.MaskCompleted || !txbDiesel.MaskCompleted || !txbGnv.MaskCompleted)
            {
                Dashboard.Instancia.AtualizarRodape("Preencha todos os campos");
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
                    string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                    Dashboard.Instancia.AtualizarRodape(primeiroErro); 
                }
                else
                {
                    controlador.GravarCombustivel(combustivel);
                    
                    Dashboard.Instancia.AtualizarRodape("Combustiveis gravados com sucesso");
                }
            } 
        }
    }
}
