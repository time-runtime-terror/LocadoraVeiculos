using LocadoraVeiculos.Controladores.ClienteModule;
using LocadoraVeiculos.Controladores.CondutorModule;
using LocadoraVeiculos.Dominio.ClienteModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WindowsApp.Features.ClienteModule
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;
        private readonly ControladorCliente controladorCliente;

        public TelaClienteForm()
        {
            InitializeComponent();
            controladorCliente = new ControladorCliente(new ControladorCondutor());
        }

        public Cliente Cliente
        {
            get => cliente;

            set
            {
                cliente = value;

                txtId.Text = cliente.Id.ToString();

                txtNome.Text = cliente.Nome;
                txtEndereco.Text = cliente.Endereco;
                txtTelefone.Text = cliente.Telefone;

                if (cliente.TipoPessoa == "Jurídica")
                    rdbPessoaJuridica.Checked = true;
                else
                    rdbPessoaFisica.Checked = true;
            }
        }

    }
}
