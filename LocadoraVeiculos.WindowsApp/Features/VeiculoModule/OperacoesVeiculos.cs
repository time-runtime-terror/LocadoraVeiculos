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

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] inserido com sucesso");
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

                tabelaVeiculo.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{tela.Veiculo.Modelo}] editado com sucesso");
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

            Veiculo veiculoSelecionado = controlador.SelecionarPorId(id);

            if (veiculoSelecionado.EstaAlugado)
            {
                Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] não pôde ser excluído pois está alugado!");
                return;
            }

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veiculo: [{veiculoSelecionado.Id}] ?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros();

                Dashboard.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionado.Modelo}] removido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = controlador.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros();

            return tabelaVeiculo;
        }

        public void AgruparRegistros()
        {
            AgrupamentoVeiculosForm telaFiltro = new AgrupamentoVeiculosForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                tabelaVeiculo.AgruparVeiculos(telaFiltro.TipoAgrupamento);
            }
        }

        public void DesagruparRegistros()
        {
            tabelaVeiculo.DesagruparVeiculos();
        }

        public void FiltrarRegistros()
        {
            
        }

        public void Pesquisar(string text)
        {
            List<Veiculo> veiculosEncontrados = controlador.Pesquisar(text);

            tabelaVeiculo.AtualizarRegistros(veiculosEncontrados);
        }
    }
}
