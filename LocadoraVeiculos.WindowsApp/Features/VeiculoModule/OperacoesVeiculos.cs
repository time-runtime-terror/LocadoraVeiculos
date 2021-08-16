using LocadoraVeiculos.WindowsApp.Shared;
using LocadoraVeiculos.Controladores.VeiculoModule;
using LocadoraVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculos.WindowsApp.Features.VeiculoModule;
using System.Collections.Generic;
using System.Windows.Forms;


namespace LocadoraVeiculos.WindowsApp.Feature.VeiculoModule
{
    public class OperacoesVeiculos : ICadastravel
    {
        private readonly ControladorVeiculo controlador = null;
        private readonly TabelaVeiculosControl tabelaVeiculo = null;

        public OperacoesVeiculos(ControladorVeiculo controladorVeiculo)
        {
            controlador = controladorVeiculo;
            tabelaVeiculo = new TabelaVeiculosControl(controladorVeiculo);
        }

        public void InserirNovoRegistro()
        {
            TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Veiculo);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                // TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tela.Tarefa.Titulo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder editar!", "Edição de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculoSelecionado = controlador.SelecionarPorId(id);

            TelaCadastrarVeiculos tela = new TelaCadastrarVeiculos();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Veiculo);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                // TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tela.Tarefa.Titulo}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veiculo: [{veiculoSelecionada.Id}] ?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                //TelaPrincipalForm.Instancia.AtualizarRodape($"Tarefa: [{tarefaSelecionada.Titulo}] removida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = controlador.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }

        public void AgruparRegistros()
        {

        }

        public void DesagruparRegistros()
        {

        }

        public void FiltrarRegistros()
        {
            
        }
    }
}
