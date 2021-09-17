using System;
using System.IO;
using System.Windows.Forms;
using LocadoraVeiculos.Infra.Configuration.CombustivelModule;
using LocadoraVeiculos.netCore.Dominio.CombustivelModule;

namespace LocadoraVeiculos.WindowsApp.Features.CombustivelModule
{
    public partial class CombustivelControl : UserControl
    {
        private Combustivel combustivel;
        private readonly CombustivelConfiguration configCombustivel = null;

        public CombustivelControl(CombustivelConfiguration configCombustivel)
        {
            InitializeComponent();
            this.configCombustivel = configCombustivel;

            txbGasolina.Text = configCombustivel.PegarValorGasolina();
            txbEtanol.Text = configCombustivel.PegarValorEtanol();
            txbDiesel.Text = configCombustivel.PegarValorDiesel();
            txbGnv.Text = configCombustivel.PegarValorGnv();

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
                    configCombustivel.GravarCombustivel(combustivel);
                    
                    Dashboard.Instancia.AtualizarRodape("Combustiveis gravados com sucesso");
                }
            } 
        }
    }
}
